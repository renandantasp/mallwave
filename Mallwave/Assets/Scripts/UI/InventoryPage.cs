using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField]
    private InventoryItem _itemPrefab;

    [SerializeField]
    private RectTransform _contentPanel;

    [SerializeField]
    private InventoryDescription _inventoryDescription;

    [SerializeField]
    private MouseFollower _follower;

    List<InventoryItem> _items = new List<InventoryItem>();

    public event Action<int> OnDescriptionRequested,
        OnItemActionRequested,
        OnStartedDragging;
    public event Action<int, int> OnSwapItems;

    private int currentlyDraggedItem = -1;

    public void Awake()
    {
        Hide();
        _follower.Toggle(false);
    }

    public void InitializeInventory(int size)
    {
        for (int i = 0; i < size; i++)
        {
            InventoryItem item = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            item.transform.SetParent(_contentPanel);
            _items.Add(item);
            item.OnItemClicked += HandleItemSelection;
            item.OnItemBeginDrag += HandleBeginDrag;
            item.OnItemDroppedOn += HandleSwap;
            item.OnItemEndDrag += HandleEndDrag;
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

    private void ResetDraggedItem()
    {
        _follower.Toggle(false);
        currentlyDraggedItem = -1;
    }
    private void HandleEndDrag(InventoryItem item)
    {
        ResetDraggedItem();
        Debug.Log("End Drag");
    }

    private void HandleSwap(InventoryItem item)
    {
        int index = _items.IndexOf(item);
        if (index == -1)
        {

            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItem, index);

    }


    private void HandleShowItemActions(InventoryItem item)
    {
        Debug.Log("Show Item Actions");

    }

    private void HandleBeginDrag(InventoryItem item)
    {
        int index = _items.IndexOf(item);
        if (index == -1) return;

        currentlyDraggedItem = index;
        HandleItemSelection(item);
        OnStartedDragging?.Invoke(index);
        Debug.Log("Begin Drag");
    }

    private void CreateDraggedItem(Sprite sprite, int quantity)
    {
        _follower.Toggle(true);
        _follower.SetData(sprite, quantity);
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

    private void ResetSelection()
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
        ResetDraggedItem();
        Debug.Log("Hide");
    }

}
