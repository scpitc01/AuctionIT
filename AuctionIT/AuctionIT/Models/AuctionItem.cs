using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionIT.Models
{
    public class AuctionItem
    {
        public int autoID { get; set; }
        public int itemID { get; set; }
        public string description { get; set; }
        public string donatedBy { get; set; }
        public double currentWinningBid { get; set; }
        public int currentWinningBidder { get; set; }
        public int associatedItem { get; set; }
    }
}