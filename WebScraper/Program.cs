using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static void Main()
        {
            // send get request and store the result
            string url = "https://basenotes.com/threads/need-help-creating-a-cedramber-accord.537211/#post-5924636";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            // turn result into html doc that can be parsed
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // get username of original poster
            var usernameElement = htmlDocument.DocumentNode.SelectSingleNode("//a[@class='username ']");
            var username = usernameElement.InnerText;
            Console.WriteLine(username);

        }
    }
}
