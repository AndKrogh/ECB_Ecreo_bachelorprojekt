using Microsoft.EntityFrameworkCore;
using Models.DbEntities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add services to the container.
//builder.Services.AddRazorComponents()
//.AddInteractiveServerComponents();

builder.Services.AddDbContext<EcBillingContext>(options =>
{
	options.UseSqlServer(
		"Server=tcp:ec-billing-server.database.windows.net,1433;Initial Catalog=EC_Billing_Db;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";",
		sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
			maxRetryCount: 3,
			maxRetryDelay: TimeSpan.FromSeconds(10),
			errorNumbersToAdd: null
		));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

//app.MapRazorComponents<App>()
//	.AddInteractiveServerRenderMode();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
