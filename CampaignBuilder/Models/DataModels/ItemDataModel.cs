using System;
using CampaignCore;
namespace CampaignBuilder.Models.DataModels
{
    public class ItemDataModel
    {
        public ItemDataModel()
        {
            var map = new ItemMapper();
            mItem = new Item(map);
        }

        public ItemDataModel(Item existing) 
        {
            mItem = existing;
        }

        private Item mItem;
    }
}
