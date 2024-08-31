using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add services to the container.
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

app.UseHttpsRedirection();



// Category
// GET
app.MapGet("/api/categories", (BangazonDbContext db) =>
{
    return db.Category.ToList();
});

// Orders
// GET All orders 
app.MapGet("/api/orders", (BangazonDbContext db) =>
{
    return db.Order.ToList();
});

// GET Single Order
app.MapGet("/api/orders/{id}", async (BangazonDbContext db, int id) =>
{
    var order = await db.Order.FindAsync(id);
    return order is not null ? Results.Ok(order) : Results.NotFound();
});

// Post New Order
app.MapPost("/api/orders", async (BangazonDbContext db, Order order) =>
{
    db.Order.Add(order);
    await db.SaveChangesAsync();
    return Results.Created($"/api/orders/{order.Id}", order);
});

// Update Order
app.MapPut("/api/orders/{id}", async (BangazonDbContext db, int id, Order updatedOrder) =>
{
    var order = await db.Order.FindAsync(id);
    if (order is null) return Results.NotFound();

    order.OrderDate = updatedOrder.OrderDate;
    order.Total = updatedOrder.Total;
    order.Status = updatedOrder.Status;
    order.UserId = updatedOrder.UserId;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Complete Order 
app.MapPost("/api/orders/{id}/complete", async (BangazonDbContext db, int id) =>
{
    var order = await db.Order.FindAsync(id);
    if (order is null) return Results.NotFound();

    order.Status = true; // Mark as complete
    await db.SaveChangesAsync();

    return Results.Ok("Thank you for your order!");
});

// Delete Order
app.MapDelete("/api/orders/{id}", async (BangazonDbContext db, int id) =>
{
    var order = await db.Order.FindAsync(id);
    if (order is null) return Results.NotFound();

    db.Order.Remove(order);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// OrderDetails
// GET All OrderDetails
app.MapGet("/api/orderdetails", async (BangazonDbContext db) =>
{
    return await db.OrderDetails.ToListAsync();
});

// Get Single OrderDetails
app.MapGet("/api/orderdetails/{id}", async (BangazonDbContext db, int id) =>
{
    var orderDetail = await db.OrderDetails.FindAsync(id);
    return orderDetail is not null ? Results.Ok(orderDetail) : Results.NotFound();
});

// Update an Existing Order Detail
app.MapPut("/api/orderdetails/{id}", async (BangazonDbContext db, int id, OrderDetails updatedOrderDetail) =>
{
    var orderDetail = await db.OrderDetails.FindAsync(id);
    if (orderDetail is null) return Results.NotFound();

    orderDetail.OrderId = updatedOrderDetail.OrderId;
    orderDetail.ProductId = updatedOrderDetail.ProductId;
    orderDetail.Quantity = updatedOrderDetail.Quantity;
    orderDetail.Price = updatedOrderDetail.Price;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Delete an Order Detail
app.MapDelete("/api/orderdetails/{id}", async (BangazonDbContext db, int id) =>
{
    var orderDetail = await db.OrderDetails.FindAsync(id);
    if (orderDetail is null) return Results.NotFound();

    db.OrderDetails.Remove(orderDetail);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Products
//GET Products
app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Product.ToList();
});

// GET Single Product
app.MapGet("/api/products/{id}", async (BangazonDbContext db, int id) =>
{
    var product = await db.Product.FindAsync(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

// Create New Product
app.MapPost("/api/products", async (BangazonDbContext db, Product product) =>
{
    db.Product.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/api/products/{product.Id}", product);
});

// Update Product
app.MapPut("/api/products/{id}", async (BangazonDbContext db, int id, Product updatedProduct) =>
{
    var product = await db.Product.FindAsync(id);
    if (product is null) return Results.NotFound();

    product.Name = updatedProduct.Name;
    product.CategoryId = updatedProduct.CategoryId;
    product.UserId = updatedProduct.UserId;
    product.Price = updatedProduct.Price;
    product.Description = updatedProduct.Description;
    product.QuantityAvailable = updatedProduct.QuantityAvailable;
    product.Image = updatedProduct.Image;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Delete Product
app.MapDelete("/api/products/{id}", async (BangazonDbContext db, int id) =>
{
    var product = await db.Product.FindAsync(id);
    if (product is null) return Results.NotFound();

    db.Product.Remove(product);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


//Users
//GET User
app.MapGet("/api/users", (BangazonDbContext db) =>
{
    return db.User.ToList();
});

// GET Single User
app.MapGet("/api/users/{id}", async (BangazonDbContext db, int id) =>
{
    var user = await db.User.FindAsync(id);
    return user is not null ? Results.Ok(user) : Results.NotFound();
});

// Create New User
app.MapPost("/api/users", async (BangazonDbContext db, User user) =>
{
    db.User.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/api/users/{user.Id}", user);
});

// Update User
app.MapPut("/api/users/{id}", async (BangazonDbContext db, int id, User updatedUser) =>
{
    var user = await db.User.FindAsync(id);
    if (user is null) return Results.NotFound();

    user.FirstName = updatedUser.FirstName;
    user.LastName = updatedUser.LastName;
    user.Email = updatedUser.Email;
    user.Role = updatedUser.Role;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Delete User
app.MapDelete("/api/users/{id}", async (BangazonDbContext db, int id) =>
{
    var user = await db.User.FindAsync(id);
    if (user is null) return Results.NotFound();

    db.User.Remove(user);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

