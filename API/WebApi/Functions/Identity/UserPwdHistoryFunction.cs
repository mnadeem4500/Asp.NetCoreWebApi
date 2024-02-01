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
    public class UserPwdHistoryFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public UserPwdHistoryFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<UserPwdHistoryFunction>();
            mapper = iMapper;
        }
        public List<UserPwdHistoryDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<UserPwdHistory>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAll();

                return mapper.Map<List<UserPwdHistoryDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<UserPwdHistoryDto>();
        }
        public UserPwdHistoryDto GetById(string usergrpId)
        {
            var bll = new BLL<UserPwdHistory>(settings.ConnectionString);
           
            try
            { 
                var entities = bll.GetEntityById(usergrpId);
                var userid = mapper.Map<UserPwdHistory, UserPwdHistoryDto>(entities);
                return userid;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Create(UserPwdHistoryDto grp)
        {
            var gbll = new BLL<UserPwdHistory>(settings.ConnectionString);
            try
            {
                var pwdhistory = mapper.Map<UserPwdHistoryDto,UserPwdHistory>(grp);
            //    pwdhistory.Password = grp.UserPassword;
                pwdhistory.Active = grp.Active;
                pwdhistory.CreationDate = grp.CreationDate;
                gbll.Add(pwdhistory);
                return pwdhistory.UserId;

            }

            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Update(UserPwdHistoryDto history)
        {
            var bll = new BLL<UserPwdHistory>(settings.ConnectionString);
            try
            { 
                var pwdhistory = bll.GetEntityById(history.UserhistoryId);
                if (pwdhistory == null)
                    return OperationResponse.NotFound.ToString();               
                pwdhistory.Password = history.UserPassword;
                pwdhistory.ChangeDate = history.ChangeDate;
                pwdhistory.Active = history.Active;
               
          
                bll.Update(pwdhistory);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
     
        public string Remove(UserPwdHistoryDto usergrp)
        {
            var dbll = new BLL<UserPwdHistory>(settings.ConnectionString);
            try
            {
                var histroydelet = dbll.GetEntityById(usergrp.UserhistoryId);
                if (histroydelet == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(histroydelet);
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
