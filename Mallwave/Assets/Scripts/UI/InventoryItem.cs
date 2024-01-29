using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler,
    IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{

    [SerializeField]
    private Image _itemImage;


    [SerializeField]
    private TMP_Text _quantity;

    [SerializeField]
    private Image _borderImg;

    [SerializeField]
    private InventoryDescription _inventoryDescription;

    public event Action<InventoryItem> OnItemClicked,
        OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
        OnRightMouseBtnClick;

    private bool _empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    public void Deselect()
    {
        this._borderImg.enabled = false;
    }
    public void Select()
    {
        this._borderImg.enabled = true;        
    }
    
    private void ResetData()
    {
        this._itemImage.gameObject.SetActive(false);
        this._empty = true;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        this._itemImage.gameObject.SetActive(true);
        this._itemImage.sprite = sprite;
        this._quantity.text = quantity.ToString();
        this._empty = false;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            this.OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            this.OnItemClicked?.Invoke(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this._empty) return;
        this.OnItemBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.OnItemEndDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Drop");
        this.OnItemDroppedOn?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
      
    }
}
