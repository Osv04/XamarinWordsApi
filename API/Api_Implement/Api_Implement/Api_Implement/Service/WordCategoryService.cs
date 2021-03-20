using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Api_Implement.Model;

namespace Api_Implement.Service
{
    //IWordCategoryService categoryService = new CategoryService();
    public class WordCategoryService : IWordCategoryService
    {
        const string APIBaseAddress = "https://wordsapiv1.p.rapidapi.com/";
        //const string Url = "https://randomfox.ca/floof/";
        public async Task<Category> GetCategory(string word)
        {
            Category categories = new Category();

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(APIBaseAddress),
                DefaultRequestHeaders =
                {
                    { "x-rapidapi-key", "704ca8d251mshe6218a98dd2f799p114d43jsn0dae0dca77d3" },
                    { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" }
                }
            };


            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"words/{word}/hasCategories").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine(json);
                categories = await Task.Run(() => JsonConvert.DeserializeObject<Category>(json)).ConfigureAwait(false);
                return categories;
            }
            
            return null;
        }
        

    }
}


//var client = new HttpClient();
//var request = new HttpRequestMessage
//{
//    Method = HttpMethod.Get,
//    RequestUri = new Uri("https://wordsapiv1.p.rapidapi.com/words/chaotic/inCategory"),
//    Headers =
//    {
//        { "x-rapidapi-key", "f3eb3d7ae5msh6261bb96f3a266ap119cb0jsn73aa941366ce" },
//        { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" },
//    },
//};
//using (var response = await client.SendAsync(request))
//{
//    response.EnsureSuccessStatusCode();
//    var body = await response.Content.ReadAsStringAsync();
//Console.WriteLine(body);
//}