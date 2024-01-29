using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class InventoryDescription : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private TMP_Text _title;

        [SerializeField]
        private TMP_Text _description;

        public void Awake()
        {
            ResetDescription();
        }

        public void ResetDescription()
        {
            _title.text = string.Empty;
            _description.text = string.Empty;
            _image.gameObject.SetActive(false);
        }

        public void SetDescription(Sprite sprite, string title, string desc)
        {
            _image.gameObject.SetActive(true);
            _image.sprite = sprite;
            _title.text = title;
            _description.text = desc;
        }


    }
}