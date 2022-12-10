using MarketPlays.Extensions;
using MarketPlays.Extensions.AddServiceFromAttribute;
using MarketPlays.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services._AddCors();
builder.Services._AddDbContext(builder.Configuration.GetConnectionString("postgres"));
builder.Services._AddIdentity();
builder.Services._AddServicesViaAttribute();
builder._AddSerilogWithConfig();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors();
app.UseExceptionHandlerMiddleware();
app._UseRequestLocalization();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
//1. Addscopedni attributga otkazish                                             **done
//2. Produce typeni yozib chiqish                                                **chala
//3. logerga telegram qosh                                                       ** oxirida
//4. categoryda SendDtoga child bn  birga convert qiladigan funksiya qoshish     ** sal chala
//5. exception qoshish                                                           **done
//6. loggger extension va service collectionga extensionslar yozish              **chala
//7. modelstate larni valideta model atttributega yozish                         **done
//8. errowhandler middleware ni exceptionlar bn tolsdirish                       **shartmas
//9.  fileserviceimni filehelperga moslashtirish
//10. ustozniki kabi libary larga bolish
//11. org va product uchun repo och
//12. idhandler ni to`liq ishlatish 


//savol nimaga Generic repo da Task qoyilmagan ayrimlarda
//getall da nimga faqat DbSet turibdi