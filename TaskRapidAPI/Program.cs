var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Eðer View de kullanýyorsan bu olmalý
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

app.UseStaticFiles(); // Eðer wwwroot kullanýyorsan

app.UseRouting(); // GEREKLÝ!

app.UseAuthorization();

// Route tanýmlama:
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Default}/{action=Index}/{id?}");
});

// Alternatif olarak sadece bunu kullanabilirsin:
app.MapDefaultControllerRoute(); // Bu yukarýdaki ile ayný iþi yapar

app.Run();
