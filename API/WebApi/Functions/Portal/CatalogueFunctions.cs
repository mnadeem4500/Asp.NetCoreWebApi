using AutoMapper;
using ExtremeClassified.BusinessLogic;
using ExtremeClassified.Core;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Portal;
using Microsoft.Extensions.Options;

namespace ExtremeClassified.WebApi.Functions.Portal
{
    public class CatalogueFunctions
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        public CatalogueFunctions(IOptions<ApplicationSettings> options, ILoggerFactory loggerFactory, IMapper mapper)
        {
            this.settings = options.Value;
            logger = loggerFactory.CreateLogger<CatalogueFunctions>();
            this.mapper = mapper;
        }

        public List<CatalogueMasterDto> GetAllMasterWithDetailsAll(bool onlyActive = true)
        {
            var bll = new BLL<CatalogueMaster>(settings.ConnectionString);
            try
            {
                var entities = bll.GetAllWithNavigationProperties(x => x.KeyField != "Eh", n => n.CatalogueDetails);

                return mapper.Map<List<CatalogueMasterDto>>(entities);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bll?.Dispose();
            }
            return new List<CatalogueMasterDto>();
        }

        public string CreateMasdter(CatalogueMasterDto catalogue)
        {
            var bll = new BLL<CatalogueMaster>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<CatalogueMaster>(catalogue);
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

        public string UpdateMaster(CatalogueMasterDto catalogue)
        {
            var bll = new BLL<CatalogueMaster>(settings.ConnectionString);
            try
            {
                var oldEntity = bll.GetSingle(x => x.KeyField == catalogue.MasterId);
                if (oldEntity is null)
                    return OperationResponse.NotFound.ToString();

                oldEntity.Description = catalogue.Description;
                oldEntity.NameField = catalogue.CatalogueName;

                bll.Update(oldEntity);

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


        public string CreateDetail(CatalogueDetailDto detail)
        {
            var bll = new BLL<CatalogueDetail>(settings.ConnectionString);
            try
            {
                var entity = mapper.Map<CatalogueDetail>(detail);
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

        public string UpdateDetail(CatalogueDetailDto detail)
        {
            var bll = new BLL<CatalogueDetail>(settings.ConnectionString);
            try
            {
                var oldEntity = bll.GetSingle(x => x.KeyField == detail.DetailId);
                if (oldEntity is null)
                    return OperationResponse.NotFound.ToString();

                oldEntity.NameField = detail.Name;

                bll.Update(oldEntity);

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
        public string DeleteMaster(string masterId)
        {
            var bllMaster = new BLL<CatalogueMaster>(settings.ConnectionString);
            var bllDetail = new BLL<CatalogueDetail>(settings.ConnectionString);

            try
            {
                var masterEntity = bllMaster.GetSingle(x => x.KeyField == masterId);
                if (masterEntity is null)
                    return OperationResponse.NotFound.ToString();

                
                var detailsToDelete = bllDetail.GetAll(x => x.MasterId == masterId);
                foreach (var detailEntity in detailsToDelete)
                {
                    bllDetail.Remove(detailEntity);
                   
                }

                
                bllMaster.Remove(masterEntity);

                return OperationResponse.Deleted.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            finally
            {
                bllMaster?.Dispose();
                
            }

            return OperationResponse.Error.ToString();
        }

    }
}
