using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteParserApi.Data.Models
{
    [Table("posts")]
    public class Post : EntityBase
    {
        public string Title { get; set; }    
        public string Description { get; set; }    
        public string Source { get; set; }    
        public DateTime? PostDate { get; set; }    
        public virtual ICollection<Media> Medias { get; set; }    
    }
}
