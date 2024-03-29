using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Inventory.Model {

    [CreateAssetMenu (menuName="Sciptable Objects/Inventory")]
    public class InventorySO : ScriptableObject
    {        
        public List<Item> inventoryItems;

        [field: SerializeField]
        public int Size { get; private set; } = 10;
        public void Initialize()
        {
            inventoryItems = new List<Item>();
            for (int i = 0; i < Size; i++)
            {                
                inventoryItems.Add(Item.GetEmptyItem());
            }
        }
        public int Money;
        public event Action<Dictionary<int, Item>> OnInventoryUpdated;
        public void AddItem(ItemSO item, int quantity = 1)
        {
            if(quantity > 0 && !IsInventoryFull())
            {
                AddNonStackableItem(item, 1);
            }
        }
    

        private int AddNonStackableItem(ItemSO item, int quantity)
        {
            Item inventoryItem = new Item
            {
                item = item,
                quantity = quantity
            };
            for (int i=0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = inventoryItem;
                    return quantity;
                }

            }
            return 0;
            
        }

        public void RemoveItem(int itemIndex, int quantity = 1)
        {
            if (inventoryItems.Count > 0)
            {
                if (inventoryItems[itemIndex].IsEmpty) return;
                int newQuantity = inventoryItems[itemIndex].quantity - quantity;
                if ( newQuantity <=0)
                    inventoryItems[itemIndex] = Item.GetEmptyItem();
                else
                    inventoryItems[itemIndex].ChangeQuantity(newQuantity);
                //InformAboutChange();
            }
        }


        private bool IsInventoryFull() =>
           inventoryItems.Where(item => item.IsEmpty).Any() == false;

        public Dictionary<int, Item> GetCurrentInventoryState()
        {
            Dictionary<int, Item> currState = new Dictionary<int, Item>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty) continue;
                currState[i] = inventoryItems[i];

            }
            Debug.Log(currState);
            return currState;
        }

        public Item GetItemAt(int index)
        {
            if (inventoryItems[index].IsEmpty) return Item.GetEmptyItem();
            return inventoryItems[index];
        }

   
        public void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }
    }


    [Serializable]
    public struct Item
    {
        public int quantity;
        public ItemSO item;

        public bool IsEmpty => item == null;

        public Item ChangeQuantity(int newQuantity)
        {
            return new Item
            {
                item = this.item,
                quantity = newQuantity
            };
        }

        public static Item GetEmptyItem() 
            => new Item
            {
                item = null,
                quantity = 0
            };
    }
}