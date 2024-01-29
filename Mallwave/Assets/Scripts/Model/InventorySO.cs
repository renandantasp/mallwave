using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    [SerializeField]
    private List<Item> inventoryItems;

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

    public void AddItem(ItemSO item, int quantity)
    {
        for (int i = 0; i < Size; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                inventoryItems[i] = new Item
                {
                    item = item,
                    quantity=quantity
                };
            }
        }
    }

    public Dictionary<int, Item> GetCurrentInventoryState()
    {
        Dictionary<int, Item> currState = new Dictionary<int, Item>();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty) continue;
            currState[i] = inventoryItems[i];

        }
        return currState;
    }

    public Item GetItemAt(int index)
    {
        if (inventoryItems[index].IsEmpty) return Item.GetEmptyItem();
        return inventoryItems[index];
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
