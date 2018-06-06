using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace Bacchus.Pages
{
    public class IndexModel : PageModel
    {
        public List<Item> Items { get; set; }
        public List<string> Categories { get; set; }

        public void OnGet()
        {
            string str = new WebClient().DownloadString("http://uptime-auction-api.azurewebsites.net/api/Auction");
            JArray json = JArray.Parse(str);

            Items = new List<Item>();
            Categories = new List<string>();
            foreach (var item in json)
            {
                Items.Add(new Item());

                string category = (item["productCategory"].ToString());
                Item cItem = Items[Items.Count - 1];
                cItem.ProductCategory = category;
                cItem.ProductID = item["productId"].ToString();
                cItem.ProductName = item["productName"].ToString();
                cItem.ProductDescription = item["productDescription"].ToString();
                cItem.BiddingEndDate = item["biddingEndDate"].ToString();

                if (!HasCategory(category))
                    Categories.Add(category);
            }
        }

        private bool HasCategory(string category)
        {
            foreach (var item in Categories)
            {
                if (item == category)
                    return true;
            }

            return false;
        }
    }
}