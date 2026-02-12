using System.Net.Http.Headers;
using NetAI.RapidApi.ViewModels;
using Newtonsoft.Json;

List<ApiSeriesViewModel>? list = new List<ApiSeriesViewModel>();
var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
    Headers =
    {
        { "x-rapidapi-key", "08c5c64495msh61c97ae9bfc26f4p1fd526jsn7ec756c6d29c" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    list = JsonConvert.DeserializeObject<List<ApiSeriesViewModel>>(body);
    list?.ForEach(x => 
        Console.WriteLine(x.rank + " " + x.title + " Film Puanı : " + x.rating + " Yapım Yılı : " + x.year));
}

request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city?city=%C4%B0stanbul&lang=TR"),
    Headers =
    {
        { "x-rapidapi-key", "08c5c64495msh61c97ae9bfc26f4p1fd526jsn7ec756c6d29c" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
}