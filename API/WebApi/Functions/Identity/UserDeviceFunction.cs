using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.BusinessLogic.Identity;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Identity
{
    public class UserDeviceFunction
    {

        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserDeviceFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserDeviceFunction>();
            mapper = iMapper;
        }
        public List<UserDeviceDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<UserDevice>(settings.ConnectionString);
            try
            {
                var entities =  bll.GetAll();

                return mapper.Map<List<UserDeviceDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<UserDeviceDto>();
        }
        public UserDeviceDto GetById(string udevice)
        {
            var bll = new BLL<UserDevice>(settings.ConnectionString);

            try
            {
                var entities = bll.GetEntityById(udevice);
                var userdevice = mapper.Map<UserDevice, UserDeviceDto>(entities);
                return userdevice;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(UserDeviceDto device)
        {
            var gbll = new BLL<UserDevice>(settings.ConnectionString);
            try
            {
                var userdevice = mapper.Map<UserDeviceDto, UserDevice>(device);
                userdevice.Active = device.Active;
                userdevice.CreationDate = device.CreationDate;
                gbll.Add(userdevice);
                return userdevice.DeviceId;

            }

            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(UserDeviceDto udevice)
        {
            var bll = new BLL<UserDevice>(settings.ConnectionString);
            try
            {
                var devices = bll.GetEntityById(udevice.UserDeviceId);
                if (devices == null)
                    return OperationResponse.NotFound.ToString();
                devices.DeviceName = udevice.DevicName;
                devices.UserId = udevice.UserId;
                devices.Vender = udevice.DeviceVender;
                devices.Model = udevice.DeviceModel;
                devices.DeviceOs = udevice.DeviceOs;
                devices.FingerPrint = udevice.FingerPrint;
                devices.Active = udevice.Active;                
                bll.Update(devices);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
             public string Remove(UserDeviceDto user)
        {
            var dbll = new BLL<UserDevice>(settings.ConnectionString);
            try
            {
                var devices = dbll.GetEntityById(user.UserDeviceId);
                if (devices == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(devices);
                return OperationResponse.Deleted.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { dbll?.Dispose(); }

            return OperationResponse.Error.ToString();


        }
    }
}
