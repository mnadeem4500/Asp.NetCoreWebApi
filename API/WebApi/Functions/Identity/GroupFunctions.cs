using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.BusinessLogic.Identity;
using ExtremeClassified.Core;
using ExtremeClassified.Core.Contracts;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Dtos.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Security.Cryptography;

namespace ExtremeClassified.WebApi.Functions.Identity
{
    public class GroupFunctions
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public GroupFunctions(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper iMapper)
        {
            settings = options.Value;
            logger = loggerFactory.CreateLogger<GroupFunctions>();
            mapper = iMapper;
        }
        public List<GroupDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<Group>(settings.ConnectionString);
            try
            {
                var entities =  bll.GetAll();

                return mapper.Map<List<GroupDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<GroupDto>();
        }
        public GroupDto GetById(string grpId)
        {
            var bll = new BLL<Group>(settings.ConnectionString);
            try
            {
                var entities = bll.GetEntityById(grpId);
                var grp = mapper.Map<Group, GroupDto>(entities);
                return grp;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return null;
        }
        public string Update(GroupDto grp)
        {
            var bll = new BLL<Group>(settings.ConnectionString);
            try
            {
                var oldGroup = bll.GetEntityById(grp.GroupId);
                if (oldGroup == null)
                    return OperationResponse.NotFound.ToString();

                oldGroup.NameField = grp.Name;
                oldGroup.Description = grp.Description;
                oldGroup.Active = grp.Active;
                bll.Update(oldGroup);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
        public string Create(GroupDto grp)
        {
            var gbll = new BLL<Group>(settings.ConnectionString);
            try
            {
                var newGroup = mapper.Map<GroupDto, Group>(grp);
                newGroup.CreationDate = DateTime.UtcNow;
                newGroup.Active = true;
                newGroup.NameField = grp.Name;

                /* var source = new GroupDto();
                 source.CreatedUser = "ass";
                 source.CreationDate = DateTime.UtcNow;
                 source.Description = "abcs";

                 var destination = new Group();

                 newGroup.CreationDate = DateTime.UtcNow;
                 newGroup.Active = true;*/
                gbll.Add(newGroup);
                return newGroup.KeyField;

            }

            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { gbll?.Dispose(); }

            return OperationResponse.Error.ToString();

        }
        public string Remove(GroupDto grp)
        {
            var dbll = new BLL<Group>(settings.ConnectionString);
            try
            {
                var grpdelet = dbll.GetEntityById(grp.GroupId);
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
