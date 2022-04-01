using System.Collections.Generic;
using System.Threading.Tasks;
using SiteParserApi.Data.Models;

namespace SiteParserApi.Data.Repositories.Abstract
{
    public interface IPostRepository
    {
        public int GetPostsCount();
        public Post GetPostById(int id);
        public IEnumerable<Post> GetAllPosts();
        public IEnumerable<Post> GetPostsBySource(string source);
        public Task SaveEntity(Post entity);
    }
}
