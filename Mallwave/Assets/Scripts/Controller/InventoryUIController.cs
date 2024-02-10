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
        private AudioClip clickSound, openSound, equipSound, closeSound;
        private AudioSource audioSrc;

        [SerializeField]
        private InventorySO inventoryData;

        [HideInInspector]
        public bool isInventoryOpen;



        void Start()
        {
            this.isInventoryOpen = false;
            PrepareUI();
            PrepareInventoryData();
            audioSrc = GetComponent<AudioSource>();
        }

        private void PrepareInventoryData()
        {
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
        }

        public void UpdateInventoryUI(Dictionary<int, Item> inventoryState)
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
            inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            inventoryUI.OnItemActionRequested += HandleItemActionRequest;
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
            audioSrc.clip = clickSound;
            audioSrc.Play();
        }
        private void HandleItemActionRequest(int itemIndex)
        {
            Item item = inventoryData.GetItemAt(itemIndex);
            if (item.IsEmpty) return;
            IItemAction itemAction = item.item as IItemAction;
            if (itemAction != null)
            {
                itemAction.PerformAction(gameObject);
                audioSrc.clip = equipSound;
                audioSrc.Play();
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!inventoryUI.isActiveAndEnabled)
                {
                    if (inventoryUI.Show())
                    {
                        isInventoryOpen = true;
                        inventoryUI.ResetAllItems();
                        foreach (var item in inventoryData.GetCurrentInventoryState())
                        {
                            inventoryUI.UpdateData(item.Key,
                                item.Value.item.ItemImage,
                                item.Value.quantity);
                        }
                        audioSrc.clip = openSound;
                        audioSrc.Play();
                    } else
                    {

                    }
                    
                }
                else
                {
                    inventoryUI.Hide();
                    isInventoryOpen = false;
                    audioSrc.clip = openSound;
                    audioSrc.Play();
                }
            }

        }
    }
}