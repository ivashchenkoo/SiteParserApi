using Microsoft.AspNetCore.Mvc;
using SiteParserApi.Data.Repositories.Abstract;
using Newtonsoft.Json;
using SiteParserApi.Data.Models;
using System.Threading.Tasks;

namespace SiteParserApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public PostController()
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        [HttpGet("all")]
        public string GetAllPosts(IPostRepository posts)
        {
            return JsonConvert.SerializeObject(posts.GetAllPosts(), _jsonSerializerSettings);
        }

        [HttpGet("{id}")]
        public string GetPostById(int id, IPostRepository posts)
        {
            return JsonConvert.SerializeObject(posts.GetPostById(id), _jsonSerializerSettings);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post, IPostRepository posts)
        {
            await posts.SaveEntity(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }
    }
}
