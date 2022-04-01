using Microsoft.AspNetCore.Mvc;
using SiteParserApi.Data.Repositories.Abstract;
using Newtonsoft.Json;
using SiteParserApi.Data.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SiteParserApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly IPostRepository _posts;

        public PostController(IPostRepository posts)
        {
            _posts = posts;
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        [HttpGet("all")]
        public string GetAllPosts()
        {
            return JsonConvert.SerializeObject(_posts.GetAllPosts(), _jsonSerializerSettings);
        }

        [HttpGet("{id}")]
        public string GetPostById(int id)
        {
            return JsonConvert.SerializeObject(_posts.GetPostById(id), _jsonSerializerSettings);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            await _posts.SaveEntity(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            try
            {
                await _posts.UpdateEntity(post);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_posts.GetPostById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
