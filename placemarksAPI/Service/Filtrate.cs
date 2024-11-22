using placemarksAPI.Model;
using placemarksAPI.Model.kml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace placemarksAPI.Service
{
    public class Filtrate
    {
        //Posso implementar um cache ou algo do tipo pra não ficar toda hora 
        //deserealizando o arquivos de dado. Faço se der tempo
        public Kml FilterFile(ExtendDataObject extendDataObject)
        {
            var kmlFiltered = ProcessKMLFile.Deserealize();

            kmlFiltered.Document.Folder!.Placemarks = FiltrarPlacemarks(extendDataObject);

            return kmlFiltered;
        }

        //Farei um Filtro mais Geral aqui.
        //Parametros referencia e ruaOuCruzamento não são obrigatorios nesse metodo.
        //Vou essa validação no Controller
        public List<Placemark> FiltrarPlacemarks(ExtendDataObject? extendDataObject = null)
        {

            var placemarks = ProcessKMLFile.Deserealize().Document.Folder?.Placemarks ?? [];

            if (extendDataObject == null)
            {
                return placemarks;
            }

            var obrigatorios = placemarks
            .Where(p => p.ExtendedData?.Data != null) // Verifica se há dados
            .Where(p =>
            {
                var dados = p.ExtendedData.Data.ToDictionary(d => d.Name, d => d.Value);

                // Checa simultaneamente CLIENTE, SITUAÇÃO e BAIRRO
                return dados.TryGetValue("CLIENTE", out var clienteValue) && clienteValue == extendDataObject.Cliente &&
                       dados.TryGetValue("SITUAÇÃO", out var situacaoValue) && situacaoValue == extendDataObject.Situacao &&
                       dados.TryGetValue("BAIRRO", out var bairroValue) && bairroValue == extendDataObject.Bairro;
            });

            var containsRef = obrigatorios;

            if (extendDataObject.Referencia != null && extendDataObject.Referencia != "")
            {
                containsRef = obrigatorios.Where(p =>
                {
                    var dados = p.ExtendedData.Data.ToDictionary(d => d.Name, d => d.Value);

                    return dados.TryGetValue("REFERENCIA", out var referenceValue) && referenceValue.Contains(extendDataObject.Referencia);
                });
            }

            var containsRuaOuCruzamento = containsRef;

            if (extendDataObject.RuaCruzamento != null && extendDataObject.RuaCruzamento != "")
            {
                containsRuaOuCruzamento = containsRef.Where(p =>
                {
                    var dados = p.ExtendedData.Data.ToDictionary(d => d.Name, d => d.Value);

                    return dados.TryGetValue("RUA/CRUZAMENTO", out var ruaOuCruzamentoValue) && ruaOuCruzamentoValue.Contains(extendDataObject.RuaCruzamento);
                });
            }

            return containsRuaOuCruzamento.ToList();
        }


        public Filters GetFilters()
        {
            var placemarks = ProcessKMLFile.Deserealize().Document.Folder?.Placemarks ?? [];

            var clientes = placemarks
            .SelectMany(p => p.ExtendedData?.Data)
            .Where(d => d.Name == "CLIENTE" && !string.IsNullOrWhiteSpace(d.Value))
            .Select(d => d.Value)
            .Distinct()
            .ToList();

            //Há situações em branco. Deixarei elas serem Listadas
            var situacoes = placemarks
            .SelectMany(p => p.ExtendedData?.Data)
            //.Where(d => d.Name == "SITUAÇÃO" && !string.IsNullOrWhiteSpace(d.Value))
            .Where(d => d.Name == "SITUAÇÃO")
            .Select(d => d.Value)
            .Distinct()
            .ToList();

             var bairros = placemarks
            .SelectMany(p => p.ExtendedData?.Data)
            .Where(d => d.Name == "BAIRRO" && !string.IsNullOrWhiteSpace(d.Value))
            .Select(d => d.Value)
            .Distinct()
            .ToList();

            return new Filters(clientes,situacoes,bairros);

        }
    }
}
