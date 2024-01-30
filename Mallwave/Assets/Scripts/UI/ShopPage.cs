using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPage : InventoryPage
{
    [SerializeField]
    private ShopDescription shopDescription;
    internal void UpdateButton(bool isBuy)
    {
        if (isBuy)
        {
            this.shopDescription.ChangeButtonText("Buy");
            return;
        }
        this.shopDescription.ChangeButtonText("Sell");

    }
}
