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
    public class UserTokenFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserTokenFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserTokenFunction>();
            mapper = iMapper;
        }
        public List<UserTokenDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<UserToken>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<UserTokenDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<UserTokenDto>();
        }

        public UserTokenDto GetById(int token)
        {
            var bll = new BLL<UserToken>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(token);
                var userToken = mapper.Map<UserToken, UserTokenDto>(entities);
                return userToken;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(UserTokenDto token)
        {
            var bll = new BLL<UserToken>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<UserTokenDto, UserToken>(token);

            
                entity.Active = token.Active;
                entity.CreationDate = token.CreationDate;
                bll.Add(entity);
                return entity.UserId;
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

        public string Update(UserTokenDto token)
        {
            var bll = new BLL<UserToken>(settings.ConnectionString);
            try
            {
                var entity = bll.GetEntityById(token.tokenId);
                if (entity == null)
                    return OperationResponse.NotFound.ToString();
                entity.UserId = token.UserId;
                entity.Value = token.TokenValue;
                entity.ExpiryDate = token.ExpiryDate;
                entity.IssueDate = token.IssueDate;
                entity.Purpose = token.Purpose;
                entity.Active = token.Active;
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



        public string Remove(UserTokenDto token)
        {
            var dbll = new BLL<UserToken>(settings.ConnectionString);
            try
            {
                var Userdelet = dbll.GetEntityById(token.tokenId);
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