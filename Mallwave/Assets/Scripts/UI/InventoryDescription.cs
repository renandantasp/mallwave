using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        this._title.text = string.Empty;
        this._description.text = string.Empty;
        this._image.gameObject.SetActive(false);
    }

    public void SetDescription(Sprite sprite, string title, string desc)
    {
        this._image.gameObject.SetActive(true);
        this._image.sprite = sprite;
        this._title.text = title;
        this._description.text = desc;  
    }


}
