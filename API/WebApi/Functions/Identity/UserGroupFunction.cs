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
    public class UserGroupFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserGroupFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserGroupFunction>();
            mapper = iMapper;
        }
        public List<UserGroupDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<UserGroup>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<UserGroupDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<UserGroupDto>();
        }

        public UserGroupDto GetById(string UsergrpId)
        {
            var bll = new BLL<UserGroup>(settings.ConnectionString);
           
            try
            {
                var entities = bll.GetEntityById(UsergrpId);
                var grp = mapper.Map<UserGroup, UserGroupDto>(entities);
                return grp;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(UserGroupDto grp)
        {
            var gbll = new BLL<UserGroup>(settings.ConnectionString);
            try
            {
                var usergroup = mapper.Map<UserGroupDto, UserGroup>(grp);
              //  usergroup.UserId = grp.UserId;
                usergroup.Active = grp.Active;
                usergroup.CreationDate = grp.CreationDate;
                gbll.Add(usergroup);
                return usergroup.UserId;

            }

            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(UserGroupDto grp)
        {
            var bll = new BLL<UserGroup>(settings.ConnectionString);
            try
            {
                var userGroup = bll.GetEntityById(grp.UserId);
                if (userGroup == null)
                    return OperationResponse.NotFound.ToString();

                userGroup.GroupId = grp.GroupId;
                userGroup.Active = grp.Active;               
                bll.Update(userGroup);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
        public string Remove(UserGroupDto grp)
        {
            var dbll = new UserGroupBLL(settings.ConnectionString);
            try
            {
                var grpdelet = dbll.GetEntityById(grp.UserId);
                if (grpdelet == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(grpdelet);
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
