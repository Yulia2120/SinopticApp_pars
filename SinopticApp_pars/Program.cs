using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text;

HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load("https://sinoptik.ua/");

var title = doc.DocumentNode.SelectNodes("//a[@class= 'sLogo']").First().InnerText;
var sityname = doc.DocumentNode.SelectNodes("//h1[@class= 'isMain']").First().InnerText;
var description = doc.DocumentNode.SelectNodes("//div[@id= 'bd1']");

Console.WriteLine(title);
Console.WriteLine();
Console.WriteLine(sityname);
Console.WriteLine();
//List<string> facts = new List<string>();
//foreach (HtmlNode li in doc.DocumentNode.SelectNodes("//div[@id='bd1']"))
//{
//    facts.Add(li.InnerText);
//}
Console.WriteLine();
//description.ToList().ForEach(x => Console.WriteLine(x.Remove("+deg")));
description.ToList().ForEach(i => Console.WriteLine(i.InnerText));

Console.WriteLine();
Console.ReadLine();





