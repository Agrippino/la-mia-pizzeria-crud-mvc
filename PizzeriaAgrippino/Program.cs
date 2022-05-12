var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //Per impostare la pagina con le nostre pizze come pagina iniziale dobbiamo cambiare il controller da Home con il nome della nostra pagina (Pizze)
    //Id sa che deve andarlo a prendere dalla root perché non viene passato come query paramiters, va a prendere quindi la pizza corrispondente
    pattern: "{controller=Pizza}/{action=Index}/{id?}");

app.Run();
