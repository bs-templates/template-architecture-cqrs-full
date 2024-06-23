using BAYSOFT.Middleware;
using BAYSOFT.Presentations.APP.Blazor.Components;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddMiddleware(builder.Configuration, typeof(Program).Assembly);

// Add services to the container.
builder.Services
	.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services
	.AddMudServices(config =>
	{
		config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
		config.SnackbarConfiguration.PreventDuplicates = false;
		config.SnackbarConfiguration.NewestOnTop = false;
		config.SnackbarConfiguration.ShowCloseIcon = true;
		config.SnackbarConfiguration.VisibleStateDuration = 1000;
		config.SnackbarConfiguration.HideTransitionDuration = 500;
		config.SnackbarConfiguration.ShowTransitionDuration = 500;
		config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
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

app.UseMiddleware();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
