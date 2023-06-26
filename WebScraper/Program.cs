using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static readonly string url = "https://basenotes.com/threads/need-help-creating-a-cedramber-accord.537211/#post-5924636";
        
        static void Main()
        {
            // send get request and load html file
            HttpClient httpClient = new();
            string html = httpClient.GetStringAsync(url).Result;
            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(html);

            // get info from html
            ScrapeHead(htmlDocument);
            ScrapeBody(htmlDocument);
         
        }



        static void ScrapeHead(HtmlDocument htmlDocument)
        {
            var titleNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='p-title-value']");
            string title = titleNode.InnerText;
            Console.WriteLine($"Title: {title}");

            var authorNode = htmlDocument.DocumentNode.SelectSingleNode("//a[@class='username  u-concealed']");
            string author = authorNode.InnerText;
            Console.WriteLine($"Original Poster: {author}");

            var postDateNode = htmlDocument.DocumentNode.SelectSingleNode("//time[@class='u-dt']");
            string postDate = postDateNode.InnerText;
            Console.WriteLine($"Post Date: {postDate}\n");
        }

        static void ScrapeBody(HtmlDocument htmlDocument)
        {
            var articleNodes = htmlDocument.DocumentNode.SelectNodes("//article[@class='message message--post js-post js-inlineModContainer  ']");

            foreach (var article in articleNodes)
            {
                string author = article.Attributes["data-author"].Value;
                Console.WriteLine($"Author: {author}");
                string time = article.SelectSingleNode(".//li[@class='u-concealed']//time[@class='u-dt']").InnerText;
                Console.WriteLine($"Date: {time}");
                string message = article.SelectSingleNode(".//div[@class='bbWrapper']").InnerText;
                Console.WriteLine($"Message: {message}\n");
            }
        }
    }
}
