using Blog_API_Slightly_Techie.Models;
using MongoDB.Driver;

namespace Blog_API_Slightly_Techie.Services
{
    public class PostService: IPostService
    {
        public readonly IMongoCollection<Post> posts;

        public PostService(IBlogDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            posts = database.GetCollection<Post>(settings.PostCollection);
        }

        public Post Create(Post post)
        {
            posts.InsertOne(post);
            return post;
        }

        public List<Post> Get()
        {
            return posts.Find(post => true).ToList();
        }

        public Post Get(string postId)
        {
            return posts.Find(post => post.postId.Equals(postId)).FirstOrDefault();
        }

        public void Remove(string postId)
        {
            posts.DeleteOne(post => post.postId == postId);
        }

        public void Update(string postId, Post post)
        {
            var filter = Builders<Post>.Filter.Eq(p => p.postId, postId);

            var update = Builders<Post>.Update
                .Set(p => p.content, post.content)
                .Set(p => p.authorName, post.authorName);

            posts.UpdateOne(filter, update);
        }
    }
}
