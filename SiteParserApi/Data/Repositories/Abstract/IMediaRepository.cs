using SiteParserApi.Data.Models;
using System.Collections.Generic;

namespace SiteParserApi.Data.Repositories.Abstract
{
    public interface IMediaRepository
    {
        public int GetMediasCount();
        public int GetMediasCountByPostId(int id);
        public Media GetMediaById(int id);
        public IEnumerable<Media> GetMediasByPostId(int id);
        public IEnumerable<Media> GetAllMedias();
    }
}
