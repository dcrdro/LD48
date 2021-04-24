using System;
using System.Collections.Generic;
using UnityEngine;

    public class Inventory : Singleton<Inventory>
    {
        public List<ItemData> items;

        public void AddItem(ItemData data)
        {
            items.Add(data);
            UiManager.Instance.InventoryUI.AddItem(data);
            __print();
        }

        public void RemoveItem(ItemData data)
        {
            items.Remove(data);
            UiManager.Instance.InventoryUI.RemoveItem(data);
            __print();
        }

        public bool HasItem(ItemData data)
        {
            return items.Contains(data);
        }
        
        void __print()
        {
            string s = "";
            foreach (var item in items)
            {
                s += item.name + " ";
            }
            print("inventory: " + s);
        }
    }
