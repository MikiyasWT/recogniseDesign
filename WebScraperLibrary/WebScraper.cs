using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebScrapperLibrary
{
    public class WebScraper
    {
        public IEnumerable<Product> ScrapeWebsite(string baseUrl, int pageCount)
        {
            for (int page = 1; page <= pageCount; page++)
            {
                var url = baseUrl + "&_pgn=" + page;
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var productNodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 's-item')]");

                if (productNodes != null)
                {
                    foreach (var productNode in productNodes)
                    {
                        var titleNode = productNode.SelectSingleNode(".//span[@role='heading']");
                        var title = titleNode?.InnerText.Trim() ?? string.Empty;
                        title = TruncateString(title, 20); // Truncate the title to a maximum of 20 characters

                        var sellerNode = productNode.SelectSingleNode(".//span[contains(@class, 's-item__seller-info-text')]");
                        var seller = sellerNode?.InnerText.Trim() ?? string.Empty;
                        seller = TruncateString(seller, 20); // Truncate the seller to a maximum of 20 characters

                        var priceNode = productNode.SelectSingleNode(".//span[contains(@class, 's-item__price')]");
                        var price = priceNode?.InnerText.Trim() ?? string.Empty;

                        var detailsNode = productNode.SelectSingleNode(".//div[contains(@class, 's-item__details-section--primary')]");
                        var details = detailsNode?.InnerText.Trim() ?? string.Empty;
                        details = TruncateString(details, 30); // Truncate the details to a maximum of 30 characters

                        string formattedPrice = price.Replace("$", "").Replace("\"", "");

                        if (double.TryParse(formattedPrice, out double parsedPrice))
                        {
                            yield return new Product
                            {
                                Title = title,
                                Seller = seller,
                                Price = parsedPrice,
                                Detail = details
                            };
                        }
                    }
                }
            }
        }

        private string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }

    public class Product
    {
        public string Title { get; set; }
        public string Seller { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
    }
}