﻿using OrtdursGateDomain;

namespace InventoryApi.Models
{
    public class ItemModelIn
    {
        public string Name { get; set; }
        public int Type { get; set; }

        public Item ToEntity()
        {
            return new Item { Name = Name, Type = (OrtdursGateDomain.Type)Type };
        }

        public static ItemModelIn FromEntity(Item item)
        {
            return new ItemModelIn
            {
                Name = item.Name,
                Type = (int)item.Type
            };
        }

    }
}
