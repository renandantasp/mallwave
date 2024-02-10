using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerEquip : ScriptableObject
{
    public EquipableItemSO clothEquipped;
    public EquipableItemSO headGearEquipped;
    public EquipableItemSO hairEquipped;

    public bool isClothEquipped()
    {
        return clothEquipped != null;
    }
    public bool isHeadGearEquipped()
    {
        return headGearEquipped != null;
    }

    public bool isHairEquipped()
    {
        if (isHeadGearEquipped()) return false;
        return hairEquipped != null;
    }
}
