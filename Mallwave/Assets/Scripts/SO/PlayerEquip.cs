using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerEquip : ScriptableObject
{
    public EquipableItemSO clothEquipped;

    public bool isClothEquipped()
    {
        return clothEquipped != null;
    }
}
