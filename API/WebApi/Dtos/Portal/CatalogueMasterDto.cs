using ExtremeClassified.Domain.Portal;

namespace ExtremeClassified.WebApi.Dtos.Portal
{
    public class CatalogueMasterDto : BaseDto
    {
        public string MasterId { get; set; }
        public string CatalogueName { get; set; }
        public string Description { get; set; }
        public List<CatalogueDetailDto> CatalogueDetails { get; set; }
    }

    public class CatalogueDetailDto : BaseDto
    {
        public string DetailId { get; set; }
        public string Name { get; set; }
    }
}
