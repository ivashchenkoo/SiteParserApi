using SiteParserApi.Data.Repositories.Abstract;

namespace SiteParserApi.Data
{
    public class DataManager
    {
        public IPostRepository Posts { get; set; }
        public IMediaRepository Medias { get; set; }
        public IMediaTypeRepository MediaTypes { get; set; }

        public DataManager(IPostRepository postRepository, IMediaRepository mediaRepository, IMediaTypeRepository mediaTypeRepository)
        {
            Posts = postRepository;
            Medias = mediaRepository;
            MediaTypes = mediaTypeRepository;
        }
    }
}
