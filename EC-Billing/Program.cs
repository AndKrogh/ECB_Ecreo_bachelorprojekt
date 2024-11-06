using EC_Billing.Components;
using ECBilling.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();

builder.Services.AddDbContext<EcBillingContext>(options =>
{
	options.UseSqlServer(
		"Server=tcp:ec-billing-server.database.windows.net,1433;Database=EC_Billing_Db;User Id=ec_billing_admin;Password=Harringoth29!;TrustServerCertificate=True;",
		sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
			maxRetryCount: 5,
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

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
