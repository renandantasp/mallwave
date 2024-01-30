using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
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
            _borderImg.enabled = false;
        }
        public void Select()
        {
            _borderImg.enabled = true;
        }

        public void ResetData()
        {
            _itemImage.gameObject.SetActive(false);
            _empty = true;
        }

        public void SetData(Sprite sprite, int quantity)
        {
            _itemImage.gameObject.SetActive(true);
            _itemImage.sprite = sprite;
            _quantity.text = quantity.ToString();
            _empty = false;

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseBtnClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_empty) return;
            OnItemBeginDrag?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnItemEndDrag?.Invoke(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("On Drop");
            OnItemDroppedOn?.Invoke(this);
        }

        public void OnDrag(PointerEventData eventData)
        {

        }
    }
}