using AutoMapper;
using ExtremeClassified.BusinessLogic.Identity;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Functions.Identity;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions
{
    public class UserRegionFunction
    {

        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserRegionFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserRegionFunction>();
            mapper = iMapper;
        }
        public UserRegionDto GetById(string uregion)
        {
            var bll = new UserRegionBLL(settings.ConnectionString);

            try
            {
                var entities = bll.GetEntityById(uregion);
                var userrigion = mapper.Map<UserRegion, UserRegionDto>(entities);
                return userrigion;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Update(UserRegionDto uregion)
        {
            var bll = new userRegionBLL(settings.ConnectionString);
            try
            {
                var region = bll.GetEntityById(uregion.RegionId);
                if (region == null)
                    return OperationResponse.NotFound.ToString();
                region.userid = uregion.UserId;
                bll.Update(region);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
        public string Add(UserRegionDto urigion)
        {
            var gbll = new UserRegionBLL(settings.ConnectionString);
            try
            {

                var region = gbll.GetEntityById(urigion.RegionId);
                if (region == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                
                gbll.Add(region);
                return region.UserId;

            }

            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Remove(UserRegionDto uregion)
        {
            var dbll = new UserDeviceBLL(settings.ConnectionString);
            try
            {
                var region = dbll.GetEntityById(uregion.RegionId);
                if (region == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(region);
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
