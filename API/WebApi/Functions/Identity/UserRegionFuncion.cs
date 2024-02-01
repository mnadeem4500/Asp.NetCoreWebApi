using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.BusinessLogic.Identity;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Identity;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Identity
{
    public class UserRegionFuncion
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserRegionFuncion(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserRegionFuncion>();
            mapper = iMapper;
        }
        public List<UserRegionDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<UserRegion>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<UserRegionDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<UserRegionDto>();
        }
        public UserRegionDto GetById(string device)
        {
            var bll = new BLL<UserRegion>(settings.ConnectionString);

            try
            {
                var entities = bll.GetEntityById(device);
                var userdevice = mapper.Map<UserRegion, UserRegionDto>(entities);
                return userdevice;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(UserRegionDto region)
        {
            var gbll = new BLL<UserRegion>(settings.ConnectionString);
            try
            {
                var entites = mapper.Map<UserRegionDto, UserRegion>(region);
             /*   entites.UserId = region.UserId;
                entites.Region = region.Region;
                entites.TimeStamp = region.TimeStamp;*/
                entites.Active = region.Active;
                entites.CreationDate = region.CreationDate;
              
                gbll.Add(entites);
                return entites.UserId;

            }

            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(UserRegionDto region)
        {
            var bll = new BLL<UserRegion>(settings.ConnectionString);
            try
            {
                var entites = bll.GetEntityById(region.RegionId);
                if (entites == null)
                entites.UserId = region.UserId;
                entites.Region = region.Region;
                entites.TimeStamp = region.TimeStamp;
                entites.Active = region.Active;
                

                bll.Update(entites);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
        

        public string Remove(UserRegionDto region)
        {
            var dbll = new BLL<UserRegion>(settings.ConnectionString);
            try
            {
                var userdelet = dbll.GetEntityById(region.RegionId);
                if (userdelet == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(userdelet);
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
