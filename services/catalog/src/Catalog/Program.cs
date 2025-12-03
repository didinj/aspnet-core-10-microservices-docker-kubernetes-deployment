using Catalog.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

// Health endpoint (for Kubernetes)
app.MapGet("/health", () =>
{
    return Results.Ok(new { status = "Healthy", time = DateTime.UtcNow });
});

// Get all products
app.MapGet("/products", () =>
{
    var products = new List<Product>
    {
        new(1, "Laptop Pro", 1599.99),
        new(2, "Mechanical Keyboard", 129.99),
        new(3, "Noise Canceling Headphones", 299.50),
    };

    return Results.Ok(products);
});

app.Run();
