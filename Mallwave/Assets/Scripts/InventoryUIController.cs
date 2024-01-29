using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryUIController : MonoBehaviour
    {
        [SerializeField]
        private InventoryPage inventoryUI;

        [SerializeField]
        private InventorySO inventoryData;

        [HideInInspector]
        public bool isInventoryOpen = false;

        public List<Item> initialItems = new List<Item>();

        void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            //inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            //foreach (Item item in inventoryData.inventoryItems)
            //{
            //    if (item.IsEmpty) continue;
            //    inventoryData.AddItem(item.item, item.quantity);
            //}
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
            inventoryUI.InitializeInventory(inventoryData.Size);
            inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            inventoryUI.OnItemActionRequested += HandleItemActionRequest;
            inventoryUI.OnStartedDragging += HandleDragging;
            inventoryUI.OnSwapItems += HandleSwapItems;
        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            Item inventoryItem = inventoryData.GetItemAt(itemIndex);
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
            Item item = inventoryData.GetItemAt(itemIndex);
            if (item.IsEmpty) return;
            inventoryUI.CreateDraggedItem(item.item.ItemImage, item.quantity);
        }
        private void HandleSwapItems(int index1, int index2)
        {
            inventoryData.SwapItems(index1, index2);
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
                }
                else
                {
                    inventoryUI.Hide();
                    isInventoryOpen = false;
                }
            }

        }
    }
}