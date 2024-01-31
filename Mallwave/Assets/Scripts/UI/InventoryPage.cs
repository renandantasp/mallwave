using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class InventoryPage : MonoBehaviour
    {
        [SerializeField]
        private InventoryItem _itemPrefab;

        [SerializeField]
        private RectTransform _contentPanel;

        [SerializeField]
        private InventoryDescription _inventoryDescription;


        List<InventoryItem> _items = new List<InventoryItem>();

        public event Action<int> OnDescriptionRequested,
            OnItemActionRequested;


        public void Awake()
        {
            Hide();
        }

        public void InitializeInventory(int size)
        {
            for (int i = 0; i < size; i++)
            {
                InventoryItem item = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
                item.transform.SetParent(_contentPanel);
                _items.Add(item);
                item.OnItemClicked += HandleItemSelection;
                item.OnRightMouseBtnClick += HandleShowItemActions;
            }
        }

        public void UpdateData(int itemIndex, Sprite itemImage,
            int itemQuantity)
        {
            if (_items.Count > 0)
            {
                _items[itemIndex].SetData(itemImage, itemQuantity);
            }

        }

  
        private void HandleShowItemActions(InventoryItem item)
        {
            int index = _items.IndexOf(item);
            if (index == -1) return;
            OnItemActionRequested?.Invoke(index);
        }

        private void HandleItemSelection(InventoryItem item)
        {
            int index = _items.IndexOf(item);
            if (index == -1) return;

            OnDescriptionRequested?.Invoke(index);

        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
            Debug.Log("Show");

        }

        public void ResetSelection()
        {
            _inventoryDescription.ResetDescription();
            DeselectAllItems();
        }
        private void DeselectAllItems()
        {
            foreach (InventoryItem item in _items)
            {
                item.Deselect();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
        {

            _inventoryDescription.SetDescription(itemImage, name, description);
            DeselectAllItems();
            _items[itemIndex].Select();
        }

        public void ResetAllItems()
        {
            foreach (var item in _items)
            {
                    item.ResetData();
                    item.Deselect();

            }
        }
    }
}