using Inventory;
using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopUIController : MonoBehaviour
{
    [SerializeField]
    private ShopPage inventoryUI;

    [SerializeField]
    private InventorySO shopkeeperData;

    [SerializeField]
    private InventorySO playerData;

    private InventorySO buyerData, sellerData;

    [HideInInspector]
    public bool isInventoryOpen = false;

    private bool isBuy;
    private int selectedItemIndex = -1;

    private void Start()
    {
        inventoryUI.Hide();
        inventoryUI.InitializeInventory(10);
        inventoryUI.OnDescriptionRequested += HandleDescription;
    }
    public void Setup(bool isBuy)
    {
        this.isBuy = isBuy;
        selectedItemIndex = -1;

        if (this.isBuy)
        {
            buyerData = shopkeeperData;
            sellerData = playerData;
        }
        else
        {
            buyerData = playerData;
            sellerData = shopkeeperData;
        }
        if (inventoryUI.Show())
        {
            inventoryUI.UpdateButton(this.isBuy);
            inventoryUI.ResetAllItems();;
            UpdateInventoryState();

        }

    }


    public void UpdateInventoryState()
    {
        inventoryUI.ResetAllItems();
        foreach (var item in buyerData.GetCurrentInventoryState())
        {
            inventoryUI.UpdateData(item.Key,
                item.Value.item.ItemImage,
                item.Value.quantity);
        }
    }

    private void HandleDescription(int itemIndex)
    {
        Item inventoryItem = buyerData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
        {
            inventoryUI.ResetSelection();
            return;
        }
        ItemSO item = inventoryItem.item;
        selectedItemIndex = itemIndex;
        string newDescription = item.Description + $"\nPrice: {item.Price}";
        newDescription += $"\nYour Money: {playerData.Money}";
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.Name, newDescription);
    }

    public void TradeItem()
    {
        if (selectedItemIndex == -1) return;
        Item item = buyerData.GetItemAt(selectedItemIndex);

        sellerData.AddItem(item.item);
        buyerData.RemoveItem(selectedItemIndex);
        if (this.isBuy)
        {
            playerData.Money -= item.item.Price;
        } else
        {
            playerData.Money += item.item.Price;
        }
        UpdateInventoryState();
        inventoryUI.ResetSelection();
        selectedItemIndex = -1;

    }


}
