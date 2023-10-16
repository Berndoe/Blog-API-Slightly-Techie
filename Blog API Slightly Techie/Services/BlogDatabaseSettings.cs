namespace Blog_API_Slightly_Techie.Services
{
    // this is to help read and store database configuration details
    public class BlogDatabaseSettings: IBlogDatabaseSettings
    {
         
        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty ;
        public string PostCollection { get; set; } = string.Empty; 

    }
}
