using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

var _fruit = new ConcurrentDictionary<string, Fruit>();        
 
app.MapGet("/fruit", () => _fruit);

app.MapGet("/fruit/{id}", (string id) =>
    _fruit.TryGetValue(id, out var fruit)                      
        ? TypedResults.Ok(fruit)                               
        : Results.NotFound());                                 
 
 
app.MapPost("/fruit/{id}", (string id, Fruit fruit) =>
    _fruit.TryAdd(id, fruit)                                   
        ? TypedResults.Created($"/fruit/{id}", fruit)          
        : Results.BadRequest(new                               
            { id = "A fruit with this id already exists" }))
    .WithParameterValidation();  
 
app.MapPut("/fruit/{id}", (string id, Fruit fruit) =>
{

    _fruit[id] = fruit;
    return Results.NoContent();                                
});

app.MapDelete("/fruit/{id}", (string id) =>
{
    _fruit.TryRemove(id, out _);                               
    return Results.NoContent();                                
});

app.UseMiddleware<CustomMiddleware>();
app.UseRouting();

app.Run();
public class Fruit()
{
    [Required]
    [MaxLength(100)]
    string Name;
    int stock;
}


public class CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
{
    private static ConcurrentDictionary<int, int> rateLimits = new();

    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation("Inspecting request.");
        bool found = context.Request.Headers.TryGetValue("API-KEY", out var value);

        if (found && rateLimits.TryGetValue(Int32.Parse(value.First()), out var hitsLeft) && hitsLeft > 0)
        {
            await next(context);
        }
        else
        {
            return;
        }
    }

    static CustomMiddleware()
    {
        rateLimits.TryAdd(1, 10);
    }
};