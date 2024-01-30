using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorManager : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer clothesRenderer;

    [SerializeField] 
    private PlayerEquip itemsEquipped;

    public void Start()
    {
        if (itemsEquipped.isClothEquipped())
        {
            clothesRenderer.sprite = itemsEquipped.clothEquipped.ItemImage;
        }
    }

    public void SetClothes(EquipableItemSO item)
    {
        itemsEquipped.clothEquipped = item;
        clothesRenderer.sprite = item.ItemImage;
    }
}
