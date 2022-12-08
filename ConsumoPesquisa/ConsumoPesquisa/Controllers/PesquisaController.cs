using ConsumoPesquisa.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumoPesquisa.Controllers
{
    public class PesquisaController : Controller
    {
        public IActionResult Index()
        {
            //IEnumerable<Pesquisa> contatos = null;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7225/api/Pesquisa");

            //    //HTTP GET
            //    var responseTask = client.GetAsync(nome);
            //    responseTask.Wait();
            //    var result = responseTask.Result;

            //    //if (result.IsSuccessStatusCode)
            //    //{
            //    //    var readTask = result.Content.ReadAsAsync<IList<Pesquisa>>();
            //    //    readTask.Wait();
            //    //    contatos = readTask.Result;
            //    //}
            //    //else
            //    //{
            //    //    contatos = Enumerable.Empty<Pesquisa>();
            //    //    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            //    //}
            //    return View(contatos);
            //}

            return View();

        }

        //public ActionResult Pesquisa()
        //{
        //    IEnumerable<Pesquisa> pesquisar = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7225/api/");

        //        //HTTP GET
        //        var responseTask = client.GetAsync("Pesquisa");
        //        responseTask.Wait();
        //        var result = responseTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<Pesquisa>>();
        //            readTask.Wait();
        //            pesquisar = readTask.Result;
        //        }
        //        return View(pesquisar);

        //    }
        //}
        //public static List<Pesquisa> GetPesquisas(string nome)
        //{
        //    string urlBase = "https://localhost:7225/";
        //    var pesquisaList = new List<Pesquisa>();
        //    var client = new RestClient(urlBase + "api/Pesquisa");
        //    var request = new RestRequest(Method.Get);
        //    IRestResponse response = client.Execute(request);
        //    return pesquisaList;
        //}
        //[HttpGet("{pesquisa}"), ActionName("Pesquisar")]
        //[Route("Pesquisar/{pesquisa:string}")]
        public async Task<Pesquisa> Pesquisar(string pesquisa)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7225/api/Pesquisa/{pesquisa}");
            var jsonString = await response.Content.ReadAsStringAsync();

            Pesquisa jsonObject = JsonConvert.DeserializeObject<Pesquisa>(jsonString);

            TempData["Titulo"] = jsonObject.Link;
            TempData["Link"] = jsonObject.Link;


            return jsonObject;
        }
    }
}
