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
    public class UserActivityFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserActivityFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserActivityFunction>();
            mapper = iMapper;
        }
       

        public List<UserActivityDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<UserActivity>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll(onlyActive);

                return mapper.Map<List<UserActivityDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<UserActivityDto>();
        }
        public UserActivityDto GetById(string user)
        {
            var bll = new BLL<UserActivity>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(user);
                var activity = mapper.Map<UserActivity, UserActivityDto>(entities);
                return activity;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(UserActivityDto activity)
        {
            var bll = new BLL<UserActivity>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<UserActivityDto, UserActivity>(activity);
                entity.CreationDate = DateTime.UtcNow;
                entity.Active = true;
                bll.Add(entity);
                return entity.NameField;


            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }

            return OperationResponse.Error.ToString();
        }
        public string Update(UserActivityDto user)
        {
            var bll = new BLL<UserActivity>(settings.ConnectionString);
            try
            {
                var activity = bll.GetEntityById(user.UserActivityId);
                if (activity == null)
                    return OperationResponse.NotFound.ToString();
                activity.Active = user.Active;
                bll.Update(activity);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }

       
        public string Remove(UserActivityDto user)
        {
            var userActivityBll = new BLL<UserActivity>(settings.ConnectionString);
            try
            {
                var activityadd = userActivityBll.GetEntityById(user.UserActivityId);
                if (activityadd == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                userActivityBll.Remove(activityadd);
                return OperationResponse.Deleted.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { userActivityBll?.Dispose(); }

            return OperationResponse.Error.ToString();


        }
    }
}
