using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Homework4
{
    class Program
    {
        static async Task Main(string[] args)
        {

            ScrapingBrowser browser = new ScrapingBrowser();

            for (int i = 1; i <= 5; i++)
            {

                WebPage homePage = browser.NavigateToPage(new Uri("https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=" + i));

                var html = homePage.Html;

                var nodes = html.CssSelect(".cvo_module_offer h2 a");

                var professionNames = nodes.Where(n => n.InnerText.Contains(".NET")).Select(n => n.InnerText);

                foreach (var name in professionNames)
                {
                    System.Console.WriteLine(name);
                }
            }
         
        }
    }
}
