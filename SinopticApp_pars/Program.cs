
var result = Parsing(url: "https://sinoptik.ua/");

object Parsing(string url)
{
    try
    {
        using(HttpClientHandler hdl = new HttpClientHandler()) // Обработчик веб- запросов
        {
            using(var client = new HttpClient(hdl))
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    if(response.IsSuccessStatusCode)  //Возвращает значение, указывающее, завершился ли успешно HTTP-ответ.
                    {
                        var html = response.Content.ReadAsStringAsync().Result;  //Сериализация содержимого HTTP в строку в качестве асинхронной операции.
                        if (!string.IsNullOrEmpty(html))
                        {
                            {
                                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                doc.LoadHtml(html);
                            }
                        }
                    }

                }
            }
        }
    }
    catch (Exception ex)
    { Console.WriteLine(ex.Message); }
}