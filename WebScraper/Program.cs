
namespace WebScraper
{
    class Program
    {    
        static void Main()
        {
            //"https://basenotes.com/threads/need-help-creating-a-cedramber-accord.537211/#post-5924636"
            string url = "https://basenotes.com/threads/argon-gas-aka-winesave-or-bht-for-preserving-acs.526896/#post-5924635";
            
            Scraper scraper = new Scraper(url);
            

            // get info from html
            scraper.ScrapeHead();
            scraper.ScrapeBody();
         
        }
    }
}
