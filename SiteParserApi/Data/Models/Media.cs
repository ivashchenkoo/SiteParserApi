using System.ComponentModel.DataAnnotations.Schema;

namespace SiteParserApi.Data.Models
{
    [Table("medias")]
    public class Media : EntityBase
    {
        public string Url { get; set; }
        public int PostId { get; set; }
        public int MediaTypeId { get; set; }
        public virtual MediaType MediaType{ get; set; }
    }
}
