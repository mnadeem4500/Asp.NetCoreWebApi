using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos;
using ExtremeClassified.WebApi.Dtos.Portal;
using Microsoft.Extensions.Options;

namespace ExtremeClassified.WebApi.Functions.Portal
{
    public class PortalFunction
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public PortalFunction(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper mapper)
        {
            this.settings = options.Value;
            logger = loggerFactory.CreateLogger<PortalFunction>();
            this.mapper = mapper;
        }

        public List<PortalDto> GetAllPortalWithDetailsAll(bool onlyActive = true)
        {
            var bll = new BLL<PortalCountry>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAllWithNavigationProperties(x => x.KeyField != "Eh", n => n.CataloCountryAdministrativeDivisiongueDetails);

                return mapper.Map<List<PortalDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<PortalDto>();
        }
        public string CreatePortal(PortalDto portal)
        {
            var bll = new BLL<PortalCountry>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<PortalCountry>(portal);
                entity.CreationDate = DateTime.UtcNow;
                entity.Active = true;

                bll.Add(entity);

                return entity.KeyField;
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
        public string UpdatePortal(PortalDto portal)
        {
            var bll = new BLL<PortalCountry>(settings.ConnectionString);
            try
            {
                var entity = bll.GetSingle(x => x.KeyField == portal.CountryID);
                if (entity is null)
                    return OperationResponse.NotFound.ToString();
                entity.Capital = portal.Capital;
                entity.NameField = portal.CountryName;
                entity.Active = portal.Active;


                bll.Update(entity);

                return OperationResponse.Updated.ToString();
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
        public string CreatCountryAdministrativeDivision(CountryAdministrativeDivisionDto detail)
        {
            var bll = new BLL<CountryAdministrativeDivision>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<CountryAdministrativeDivision>(detail);
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
        public string UpdateCountryAdministrativeDivision(CountryAdministrativeDivisionDto detail)
        {
            var bll = new BLL<CountryAdministrativeDivision>(settings.ConnectionString);
            try
            {
                var entity = bll.GetSingle(x => x.KeyField == detail.id);
                if (entity is null)
                    return OperationResponse.NotFound.ToString();

                entity.NameField = detail.name;
                entity.Active = detail.Active;
                entity.DivisionType = detail.DivisionType;


                bll.Update(entity);

                return OperationResponse.Updated.ToString();
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


    }
}
