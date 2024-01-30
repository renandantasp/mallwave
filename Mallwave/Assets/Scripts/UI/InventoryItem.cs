using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class InventoryItem : MonoBehaviour, IPointerClickHandler
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
            OnRightMouseBtnClick;


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
        }

        public void SetData(Sprite sprite, int quantity)
        {
            _itemImage.gameObject.SetActive(true);
            _itemImage.sprite = sprite;
            _quantity.text = quantity.ToString();

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

    }
}