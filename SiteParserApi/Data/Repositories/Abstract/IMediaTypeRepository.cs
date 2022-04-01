using System.Collections.Generic;
using SiteParserApi.Data.Models;

namespace SiteParserApi.Data.Repositories.Abstract
{
    public interface IMediaTypeRepository
    {
        public int GetMediaTypesCount();
        public MediaType GetMediaTypeById(int id);
        public IEnumerable<MediaType> GetAllMediaTypes();
    }
}
