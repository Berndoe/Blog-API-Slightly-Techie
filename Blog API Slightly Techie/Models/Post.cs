using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Blog_API_Slightly_Techie.Models
{
    public class Post
    {
        [BsonId] // to make mongo db take the post id as the document id
        [BsonRepresentation(BsonType.String)]
        public string postId { get; set; } = string.Empty;

        [BsonElement("authorName")] // mongo db will use this name as the attribute name
        public string authorName { get; set; } = string.Empty;

        [BsonElement("content")] 
        public string content { get; set; } = string.Empty;

        [BsonElement("timeUpdated")]
        public DateTime timePublished { get; set; }

    }
}
