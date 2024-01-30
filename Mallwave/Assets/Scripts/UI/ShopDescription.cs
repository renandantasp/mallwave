using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopDescription : InventoryDescription
{
    [SerializeField]
    private TMP_Text buttonText;

    public void ChangeButtonText(string text)
    {
        buttonText.text = text;
    }
}
