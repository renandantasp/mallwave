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
