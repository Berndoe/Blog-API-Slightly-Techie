namespace Blog_API_Slightly_Techie.Services
{
    public interface IBlogDatabaseSettings
    {
         
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string PostCollection { get; set; }
    
    }
}
