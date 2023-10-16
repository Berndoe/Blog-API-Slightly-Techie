using Blog_API_Slightly_Techie.Models;
using Blog_API_Slightly_Techie.Services;
using Microsoft.AspNetCore.Mvc;

namespace Post_API_Slightly_Techie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        public ActionResult<Post> Create([FromBody] Post post)
        {
            var existingPost = postService.Get(post.postId);

            if (existingPost != null)
                return BadRequest($"The post with ID {post.postId} already exists");

            postService.Create(post);
            return post;

        }

        [HttpGet("{postId}")]
        public ActionResult<Post> Get(string postId)
        {
            var post = postService.Get(postId);

            if (post == null)
                return NotFound($"Post with ID {postId} not found");
            return post;
        }

        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return postService.Get();
        }

        [HttpPut("{postId}")]
        public ActionResult Put(string postId, [FromBody] Post post)
        {
            var existingPost = postService.Get(postId);

            if (existingPost == null)
                return NotFound($"Post with ID {postId} not found");

            postService.Update(postId, post);
            return Ok(post);

        }

        [HttpDelete("{postId}")]
        public ActionResult Delete(string postId)
        {
            var post = postService.Get(postId);

            if (post == null)
                return NotFound($"Post with ID {postId} not found");

            postService.Remove(post.postId);
            return Ok($"Post with ID {postId} has been deleted");
        }
    }
}