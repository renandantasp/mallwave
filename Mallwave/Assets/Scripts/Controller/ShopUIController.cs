using Inventory.Model;
using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    [SerializeField]
    private InventoryPage inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;

    [HideInInspector]
    public bool isInventoryOpen = false;

    void Start()
    {
        PrepareUI();
        PrepareInventoryData();
    }

    private void PrepareInventoryData()
    {
        inventoryData.OnInventoryUpdated += UpdateInventoryUI;
        OnSetActive();

    }

    public void OnSetActive()
    {
        foreach (var item in inventoryData.GetCurrentInventoryState())
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
        isInventoryOpen = false;
        inventoryUI.InitializeInventory(inventoryData.Size);
        inventoryUI.OnDescriptionRequested += HandleDescription;
        inventoryUI.OnItemActionRequested += HandleItemAction;
        Debug.Log("Preparing UI");
    }

    private void HandleDescription(int itemIndex)
    {
        Debug.Log(inventoryData.inventoryItems[itemIndex]);
        Item inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
        {
            inventoryUI.ResetSelection();
            return;
        }
        ItemSO item = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.Name, item.Description);
    }
    private void HandleItemAction(int itemIndex)
    {
        Debug.Log(inventoryData.inventoryItems[itemIndex]);
        Item item = inventoryData.GetItemAt(itemIndex);
        if (item.IsEmpty) return;
        IItemAction itemAction = item.item as IItemAction;
        if (itemAction != null)
        {
            itemAction.PerformAction(gameObject);
        }
    }
}
