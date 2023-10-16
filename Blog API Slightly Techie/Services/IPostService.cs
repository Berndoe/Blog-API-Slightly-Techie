using Blog_API_Slightly_Techie.Models;

namespace Blog_API_Slightly_Techie.Services
{
    public interface IPostService
    {

        List<Post> Get();
        Post Get(string postId);
        Post Create(Post post);
        void Update(string postId, Post post);
        void Remove(string postId);

    }
}
