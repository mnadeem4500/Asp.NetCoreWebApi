using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.BusinessLogic.Identity;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Dtos.Portal;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ExtremeClassified.WebApi.Functions.Identity
{
    public class RoleFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public RoleFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper mapper)
        {
            this.settings = options.Value;
            logger = loggerFactory.CreateLogger<RoleFunction>();
            this.mapper = mapper;
        }
        public List<RoleDto> GetAll(bool onlyActive = true)
        {
            var bll = new BLL<Role>(settings.ConnectionString);
            try
            {
                var entities =  bll.GetAll();

                return mapper.Map<List<RoleDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<RoleDto>();
        }
        public string Create(RoleDto role)
        {
            var bll = new BLL<Role>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<RoleDto, Role>(role);
                entity.CreationDate = DateTime.UtcNow;
                entity.Active = true;
              /*  entity.NameField = role.RoleName;
                entity.Description = role.RoleDescription;*/
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
        public string Update(RoleDto role)
        {
            var bll = new BLL<Role>(settings.ConnectionString);
            try
            {
                var oldrole = bll.GetEntityById(role.RoleId);
                if (oldrole == null)
                    return OperationResponse.NotFound.ToString();

                oldrole.NameField = role.RoleName;
                oldrole.Active = role.Active;
                oldrole.Description = role.RoleDescription;
                bll.Update(oldrole);

                return OperationResponse.Updated.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exeption on ({MethodBase.GetCurrentMethod()?.Name}) {ex.Message}");
            }
            finally { bll?.Dispose(); }

            return OperationResponse.Error.ToString();
        }
        public string Remove(RoleDto role)
        {
            var dbll = new BLL<Role>(settings.ConnectionString);
            try
            {
                var roledelet = dbll.GetEntityById(role.RoleId);
                if (roledelet == null)
                {
                    return OperationResponse.NotFound.ToString();
                }
                dbll.Remove(roledelet);
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

