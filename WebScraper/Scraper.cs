using System;
using HtmlAgilityPack;
using System.Net.Http;


namespace WebScraper
{
    public class Scraper
    {
        string url { get; set; }
        HttpClient httpClient = new();
        string html;
        HtmlDocument htmlDocument = new();

        public Scraper(string pUrl)
        {
            url = pUrl;
            // send get request and load html file      
            html = httpClient.GetStringAsync(url).Result;
            htmlDocument.LoadHtml(html);
        }

        public void ScrapeHead()
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

        public void ScrapeBody()
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
