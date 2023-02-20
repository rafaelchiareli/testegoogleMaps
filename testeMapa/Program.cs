// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using (var http = new HttpClient())
{

    //calcula a distancia entre 2 pontos em km 
    //var response = await http.GetAsync("https://maps.googleapis.com/maps/api/distancematrix/json?origins=Washington%2C%20DC&destinations=New%20York%20City%2C%20NY&units=imperial&key=AIzaSyBXuoBcyNzqbObSA5e403g1zx66UAXP39E");
    var response = await http.GetAsync("https://maps.googleapis.com/maps/api/distancematrix/json?origins=-22.46023085542186,-44.48074470278135&destinations=-22.501165098058753,-44.015283649123795&key=AIzaSyBXuoBcyNzqbObSA5e403g1zx66UAXP39E");
    var json = await response.Content.ReadAsStringAsync();
    //var resposta = JsonConvert.SerializeObject(response.Content.ReadAsStringAsync());

    JObject dados = JObject.Parse(json);
    var origens = dados.Root;
   
    var enderecoDestino = origens["destination_addresses"].First;
    var endereciOrigem = origens["origin_addresses"].First;

    var rows = dados["rows"];
    var resultados = rows.First["elements"];
    var distancia = resultados.First["distance"]["value"];

    //exemplo de retorno do json.

//    {
//        "destination_addresses": [
//        "R. 2, 285 - Planalto do Sol, Pinheiral - RJ, 27197-000, Brasil"
//],
//"origin_addresses": [
//"R. 3, 182 - São Caetano, Resende - RJ, 27532-340, Brasil"
//],
//"rows": [
//{
//            "elements": [
//            {
//                "distance": {
//                    "text": "74,3 km",
//"value": 74262
//                },
//"duration": {
//                    "text": "1 hora 10 minutos",
//"value": 4170
//},
//"status": "OK"
//            }
//]
//}
//],
//"status": "OK"
//}








}
