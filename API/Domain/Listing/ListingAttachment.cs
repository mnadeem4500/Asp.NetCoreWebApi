using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExtremeClassified.Domain.Listing
{
    [Table("ListingAttachments")]
    public class ListingAttachment : CommonEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("Id")]
        public new int KeyField { get; set; }


        [Required, MaxLength(150), Column("Type")]
        public new string NameField { get; set; }

        [MaxLength(512)]
        public string Url { get; set; }

        public int SortOrder { get; set; }

        [ForeignKey("Product"), MaxLength(50)]
        public string ProductId { get; set; }

        public virtual Listing Product { get; set; }
    }
}