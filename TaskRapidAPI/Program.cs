var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // E�er View de kullan�yorsan bu olmal�
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

app.UseStaticFiles(); // E�er wwwroot kullan�yorsan

app.UseRouting(); // GEREKL�!

app.UseAuthorization();

// Route tan�mlama:
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Default}/{action=Index}/{id?}");
});

// Alternatif olarak sadece bunu kullanabilirsin:
app.MapDefaultControllerRoute(); // Bu yukar�daki ile ayn� i�i yapar

app.Run();
