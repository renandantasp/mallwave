using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
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
    }

    private void PrepareUI()
    {
        this.inventoryUI.InitializeInventory(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        this.inventoryUI.OnStartedDragging += HandleDragging;
        this.inventoryUI.OnSwapItems += HandleSwapItems;

    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        Item inventoryItem = this.inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
        {
            inventoryUI.ResetSelection();
            return;
        }
        ItemSO item = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.Name, item.Description);
    }
    private void HandleItemActionRequest(int itemIndex)
    {
        throw new NotImplementedException();
    }

    private void HandleDragging(int itemIndex)
    {
        throw new NotImplementedException();
    }
    private void HandleSwapItems(int index1, int index2)
    {
        throw new NotImplementedException();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryUI.isActiveAndEnabled)
            {
                inventoryUI.Show();
                isInventoryOpen = true;
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key,
                        item.Value.item.ItemImage,
                        item.Value.quantity);
                }
            } else
            {
                inventoryUI.Hide();
                isInventoryOpen = false;
            }
        }

    }
}
