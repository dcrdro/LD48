using System;
using System.Collections.Generic;
using UnityEngine;

    public class Inventory : Singleton<Inventory>
    {
        public List<ItemData> items;

        public ItemData selectedItem;

        public ItemData beijd;
        void Start()
        {
            AddItem(beijd);
        }

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

        public void SelectItem(int index)
        {
            int selIdx = -1;

            if (index >= items.Count || index < 0)
            {
                selectedItem = null;
            }
            else if (items[index] == selectedItem)
            {
                selectedItem = null;
            }
            else
            {
                selectedItem = items[index];
                selIdx = index;
            }
            print("sel idx: " + selIdx);
            UiManager.Instance.InventoryUI.SelectItem(selIdx);

            if (selectedItem != null && selectedItem.IsShowable)
            {
                UiManager.Instance.ShowItem(selectedItem.showUIObject);
            }
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

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectItem(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectItem(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectItem(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectItem(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectItem(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                SelectItem(5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SelectItem(6);
            }
            
        }
    }
