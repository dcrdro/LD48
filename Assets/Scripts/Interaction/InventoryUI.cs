﻿using System.Collections.Generic;
using UnityEngine;

    public class InventoryUI : MonoBehaviour
    {
        public Transform root;
        public ItemUI itemUIPrefab;

        List<ItemUI> items = new List<ItemUI>();
        
        public void AddItem(ItemData data)
        {
            var instance = Instantiate(itemUIPrefab, root);
            instance.SetIcon(data.icon);
            instance.SetName(data.name);
            items.Add(instance);
        }
        
        public void RemoveItem(ItemData data)
        {
            var item =items.Find(i => i.name.text == data.name);
            Destroy(item.gameObject);
            items.Remove(item);
        }
    }
