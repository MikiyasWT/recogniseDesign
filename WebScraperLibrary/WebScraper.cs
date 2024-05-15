
using HtmlAgilityPack;
using System;
using System.Collections.Generic;


namespace WebScrapperLibrary;
    public class WebScraper
    {
        public List<Product> ScrapeWebsite(string url)
        {


            var web = new HtmlWeb();
            var doc = web.Load(url);

            var products = new List<Product>();

            // Identify the HTML elements that contain product information
            var productNodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 's-item')]");

            if (productNodes != null)
            {
                foreach (var productNode in productNodes)
                {
                    var titleNode = productNode.SelectSingleNode(".//span[@role='heading']");
                    var title = titleNode?.InnerText.Trim() ?? string.Empty;

                    var sellerNode = productNode.SelectSingleNode(".//span[contains(@class, 's-item__seller-info-text')]");
                    var seller = sellerNode?.InnerText.Trim() ?? string.Empty;

                    var priceNode = productNode.SelectSingleNode(".//span[contains(@class, 's-item__price')]");
                    var price = priceNode?.InnerText.Trim() ?? string.Empty;

                    var detailsNode = productNode.SelectSingleNode(".//div[contains(@class, 's-item__details-section--primary')]");
                    var details = detailsNode?.InnerText.Trim() ?? string.Empty;

                    var product = new Product
                    {
                        Title = title,
                        Seller = seller,
                        Price = price,
                        Details = details
                    };

                    products.Add(product);
                }
            }

            return products;
        }
    }

    public class Product
    {
        public string Title { get; set; }
        public string Seller { get; set; }
        public string Price { get; set; }
        public string Details { get; set; }
    }









// using HtmlAgilityPack;

// namespace WebScrapperLibrary;
// public class WebScraper
// {
//     public List<Product> ScrapeWebsite(string url)
//     {
//         var web = new HtmlWeb();
//         var doc = web.Load(url);

//         var products = new List<Product>();

//         // Identify the HTML elements that contain product information
//         var productNodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 's-item')]");

//         if (productNodes != null)
//         {
//             foreach (var productNode in productNodes)
//             {
//                 // Extract the title from each product node
//                 var titleNode = productNode.SelectSingleNode(".//div[contains(@class, 's-item__title')]/span[@role='heading']");
//                 var title = titleNode?.InnerText.Trim() ?? string.Empty;

//                 // Extract the status from each product node
//                 var statusNode = productNode.SelectSingleNode(".//div[contains(@class, 's-item__subtitle')]/span[@class='SECONDARY_INFO']");
//                 var status = statusNode?.InnerText.Trim() ?? string.Empty;

//                 // Extract the price from each product node
//                 var priceNode = productNode.SelectSingleNode(".//span[contains(@class, 's-item__price')]");
//                 var price = priceNode?.InnerText.Trim() ?? string.Empty;

//                 // Extract the seller from each product node
//                 var sellerNode = productNode.SelectSingleNode(".//span[contains(@class, 's-item__seller-info-text')]");
//                 var seller = sellerNode?.InnerText.Trim() ?? string.Empty;

//                 // Create a new Product object and populate its properties
//                 var product = new Product
//                 {
//                     Title = title,
//                     Status = status,
//                     Price = price,
//                     Seller = seller
//                 };

//                 products.Add(product);
//             }
//         }

//         return products;
//     }
// }


//    public class Product
//     {
//         public string Title { get; set; }
//         public string Seller { get; set; }
//         public string Price { get; set; }
//         public string Details { get; set; }
//     }
