using Abot.Crawler;
using Abot.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            
        }

        private static IWebCrawler GetDefaultWebCrawler()
        {
            return new PoliteWebCrawler();
        }

        private static IWebCrawler GetManuallyConfigureWebCrawler()
        {
            CrawlConfiguration config = new CrawlConfiguration();
            config.CrawlTimeoutSeconds = 0;
            config.DownloadableContentTypes = "text/html, text/plain";
            config.IsExternalPageCrawlingEnabled = false;
            config.IsExternalPageLinksCrawlingEnabled = false;
            config.IsRespectRobotsDotTextEnabled = false;
            config.IsUriRecrawlingEnabled = false;
            config.MaxConcurrentThreads = 10;
            config.MaxPagesToCrawl = 10;
            config.MaxPagesToCrawlPerDomain = 0;
            config.MinCrawlDelayPerDomainMilliSeconds = 1000;

            config.ConfigurationExtensions.Add("someKey1", "someValue1");
            config.ConfigurationExtensions.Add("someKey2", "someValue2");

            return new PoliteWebCrawler(config, null, null, null, null, null, null, null, null);
        }

        private static IWebCrawler GetCustomBehaviourUsingLambdaWebCrawler()
        {
            IWebCrawler crawler = GetDefaultWebCrawler();

            return crawler;
        }

        private static Uri GetSiteToCrawl(string [] args)
        {
            string userInput = "";
            if (args.Length < 1)
            {
                Console.WriteLine("Please enter ABSOLUTE url to crawl:");
                userInput = Console.ReadLine();
            }
            else
            {
                userInput = args[0];
            }

            if (string.IsNullOrWhiteSpace(userInput))
            {
                throw new ApplicationException("Site url to crawl is a required parameter");
            }

            return new Uri(userInput);
        }

        private static void PrintDisclaimer()
        {
            PrintAttensionTest("The demo is connfigured to crawl only 10 pages and will wait 1 second in between http requests");
        }

        private static void PrintAttensionTest(string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = originalColor;
        }

        static void crawler_ProcessPageCrawlStarting(object sender, PageCrawlStartingArgs e)
        {

        }

        static void crawler_ProcessPageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
        {

        }

        static void crawler_PageLinksCrawlDissallowed(object sender, PageLinksCrawlDisallowedArgs e)
        {

        }

        static void crawler_PageCrawlDissallowed(object sender, PageCrawlDisallowedArgs e)
        {

        }
    }
}
