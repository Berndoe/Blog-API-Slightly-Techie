using Blog_API_Slightly_Techie.Services;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.

// getting section of database settings from the apps.json file and map to BlogDatabaseSettings
builder.Services.Configure<BlogDatabaseSettings>(
                builder.Configuration.GetSection("BlogDatabaseSettings"));

builder.Services.AddSingleton<IBlogDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<BlogDatabaseSettings>>().Value);

// specifying to MongoDB the connection string 
builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("BlogDatabaseSettings:ConnectionString")));

// adding instances of the collection services
builder.Services.AddScoped<IPostService, PostService>();

// allowing requests from different sources (overriding CORS policy)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
