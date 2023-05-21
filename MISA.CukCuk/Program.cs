using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.MaterialBL;
using MISA.CukCuk.BL.MaterialCategoryBL;
using MISA.CukCuk.BL.StockBL;
using MISA.CukCuk.BL.UnitBL;
using MISA.CukCuk.DL;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.MaterialCategoryDL;
using MISA.CukCuk.DL.MaterialDL;
using MISA.CukCuk.DL.StockDL;
using MISA.CukCuk.DL.UnitDL;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com");
                      });
}); 
// Add services to the container.
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySQL");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped<IMaterialDL, MaterialDL>();
builder.Services.AddScoped<IMaterialBL, MaterialBL>();
builder.Services.AddScoped<IStockDL, StockDL>();
builder.Services.AddScoped<IStockBL, StockBL>();
builder.Services.AddScoped<IUnitDL, UnitDL>();
builder.Services.AddScoped<IUnitBL, UnitBL>();
builder.Services.AddScoped<IMaterialCategoryDL, MaterialCategoryDL>();
builder.Services.AddScoped<IMaterialCategoryBL, MaterialCategoryBL>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                      });
});
var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
