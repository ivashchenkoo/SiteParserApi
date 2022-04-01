using System.ComponentModel.DataAnnotations.Schema;

namespace SiteParserApi.Data.Models
{
    [Table("mediatypes")]
    public class MediaType : EntityBase
    {
        public string Type { get; set; }
    }
}
