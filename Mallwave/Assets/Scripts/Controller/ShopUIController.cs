using Inventory.Model;
using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        inventoryUI.Hide();
    }
    public void Setup(bool isBuy)
    {
        if (isBuy)
        {
            buyerData = shopkeeperData;
            sellerData = playerData;
        }
        else
        {
            buyerData = playerData;
            sellerData = shopkeeperData;
        }
        PrepareUI();
        PrepareInventoryData();
        inventoryUI.Show();
    }

    private void PrepareInventoryData()
    {
        buyerData.OnInventoryUpdated += UpdateInventoryUI;
        OnSetActive();

    }

    public void OnSetActive()
    {
        foreach (var item in buyerData.GetCurrentInventoryState())
        {
            inventoryUI.UpdateData(item.Key,
                item.Value.item.ItemImage,
                item.Value.quantity);
        }
    }

    private void UpdateInventoryUI(Dictionary<int, Item> inventoryState)
    {
        inventoryUI.ResetAllItems();
        foreach (var item in inventoryState)
        {
            inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage,
                item.Value.quantity);
        }
    }

    private void PrepareUI()
    {
        inventoryUI.InitializeInventory(buyerData.Size);
        inventoryUI.OnDescriptionRequested += HandleDescription;
        inventoryUI.OnItemActionRequested += HandleItemAction;
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
        string showDescription = item.Description + $"\nPrice: {item.Price}";
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.Name, item.Description + $"\nPrice: {item.Price}");
    }
    private void HandleItemAction(int itemIndex)
    {
        Debug.Log(itemIndex);
    }
}
