using AutoMapper;
using ExtremeClassified.BusinessLogic.Identity;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Identity;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Identity
{
    public class UserAccessFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserAccessFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserActivityFunction>();
            mapper = iMapper;
        }
        public List<UserAccessDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<UserAccess>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<UserAccessDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<UserAccessDto>();
        }

        public UserAccessDto GetById(int uaccessid)
        {
            var bll = new BLL<UserAccess>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(uaccessid);
                var access = mapper.Map<UserAccess, UserAccessDto>(entities);
                return access;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(UserAccessDto access)
        {
            var bll = new BLL<UserAccess>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<UserAccessDto, UserAccess>(access);
                /*   entity.Id = access.AccessId;
                   entity.UserId = access.UserId;
                   entity.Monday = access.Monday;
                   entity.Tuesday = access.Tuesday;
                   entity.Wednesday = access.Wednesday;
                   entity.Thursday = access.Thursday;
                   entity.Friday = access.Friday;
                   entity.Saturday = access.Saturday;
                   entity.Sunday = access.Sunday;
                   entity.AllDay = access.AccessAllDay;
                   entity.Active = access.Active;
                   entity.CreationDate = access.CreationDate;
                   entity.StartTime = access.AccessStart;
                   entity.EndTime = access.AccessEnd;*/
                entity.CreationDate = access.CreationDate;
                entity.Active = access.Active;
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

        public string Update(UserAccessDto access)
        {
            var bll = new BLL<UserAccess>(settings.ConnectionString);
            try
            { 
                var entity = bll.GetEntityById(access.AccessId);
                if (entity == null)
                    return OperationResponse.NotFound.ToString();

                entity.UserId = access.UserId;
                entity.Monday = access.Monday;
                entity.Tuesday = access.Tuesday;
                entity.Wednesday = access.Wednesday;
                entity.Thursday = access.Thursday;
                entity.Friday = access.Friday;
                entity.Saturday = access.Saturday;
                entity.Sunday = access.Sunday;
                entity.AllDay = access.AccessAllDay;
                entity.StartTime = access.AccessStart;
                entity.EndTime = access.AccessEnd;
                entity.Active = access.Active;
                bll.Update(entity); 

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }


       
        public string Remove(UserAccessDto user)
        {
            var dbll = new BLL<UserAccess>(settings.ConnectionString);
            try
            {
                var Userdelet = dbll.GetEntityById(user.AccessId);
                if (Userdelet == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(Userdelet);
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
