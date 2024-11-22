//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using placemarksAPI.Model;
using placemarksAPI.Model.kml;
using placemarksAPI.Service;
using System.Text;
using System.Text.Json;

ExtendDataObject extendDataObject = new() 
{
    RuaCruzamento = "AV.",
    Referencia = "SEMAFORO",
    Bairro = "13 DE JULHO",
    Situacao = "",
    Cliente = "GRADE"
};

var teste = new Filtrate();

var plk = teste.FilterFile(extendDataObject);

var file = Tools.SerializeToXml(plk);

File.WriteAllText("C:\\Users\\Thiago\\Desktop\\newKlm.xml", file);

Console.ReadLine();
