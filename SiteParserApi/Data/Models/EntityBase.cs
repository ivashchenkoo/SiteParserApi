using System.ComponentModel.DataAnnotations;

namespace SiteParserApi.Data.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
