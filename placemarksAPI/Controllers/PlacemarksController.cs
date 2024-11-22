using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using placemarksAPI.Model;
using placemarksAPI.Model.kml;
using placemarksAPI.Service;
using System.Linq;
using System.Net;

namespace placemarksAPI.Controllers
{
    [ApiController]
    [Route("/api/placemarks")]
    public class PlacemarksController : Controller
    {
        public Filtrate filtrate = new();

        [HttpGet("filters")]
        public Filters GetFilters()
        {
            return filtrate.GetFilters();
        }

        //[HttpGet]
        //public List<Placemark> GetAllplacemarks()
        //{
        //    return filtrate.FiltrarPlacemarks();
        //}

        [HttpPost]
        public List<Placemark> GetPlacemarksList(ExtendDataObject extendDataObject)
        {
            VerifyFilters(extendDataObject);
            return filtrate.FiltrarPlacemarks(extendDataObject);
        }

        [HttpPost("/api/placemarks/export")]
        public IActionResult DownloadFile(ExtendDataObject extendDataObject)
        {
            VerifyFilters(extendDataObject);
            try
            {

                var kmlFile = filtrate.FilterFile(extendDataObject);
                var XmlKmlFile = Tools.SerializeToXml(kmlFile);

                var fileStream = new MemoryStream();
                using (var writer = new StreamWriter(fileStream, leaveOpen: true))
                {
                    writer.Write(XmlKmlFile);
                    writer.Flush();
                };
                fileStream.Position = 0;

                return File(fileStream, "application/vnd.google-earth.kml+xml", "DIRECIONADORES2.kml");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao gerar o arquivo KML.");
            }
        }

        private void VerifyFilters(ExtendDataObject extendDataObject)
        {
            var filters = filtrate.GetFilters();

            try
            {
                // Validação correta dos filtros
                bool clienteValido = filters.Cliente.Contains(extendDataObject.Cliente);
                bool situacaoValida = filters.Situacao.Contains(extendDataObject.Situacao);
                bool bairroValido = filters.Bairro.Contains(extendDataObject.Bairro);
                bool referenciaValida = !string.IsNullOrEmpty(extendDataObject.Referencia) && extendDataObject.Referencia.Length >= 3;
                bool ruaCruzamentoValido = !string.IsNullOrEmpty(extendDataObject.RuaCruzamento) && extendDataObject.RuaCruzamento.Length >= 3;

                if (!(clienteValido && situacaoValida && bairroValido && referenciaValida && ruaCruzamentoValido))
                {
                    throw new BadHttpRequestException("Filtros de pesquisa incorretos.");
                }
            }
            catch
            {
                throw new BadHttpRequestException("Filtros de pesquisa incorretos.");
            }
        }

    }
}
