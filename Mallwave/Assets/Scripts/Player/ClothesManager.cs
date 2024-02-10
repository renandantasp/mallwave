using Inventory.Model;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{

    public Animator clothesRenderer;
    public Animator headWearRenderer;

    [SerializeField] 
    private PlayerEquip itemsEquipped;

    public void Start()
    {
        if (itemsEquipped.isClothEquipped())
        {
            clothesRenderer.runtimeAnimatorController = itemsEquipped.clothEquipped.itemAnimator;

        }
        if (itemsEquipped.isHeadGearEquipped())
        {
            headWearRenderer.runtimeAnimatorController = itemsEquipped.headGearEquipped.itemAnimator;
            return;

        }
        if (itemsEquipped.isHairEquipped())
        {
            headWearRenderer.runtimeAnimatorController = itemsEquipped.hairEquipped.itemAnimator;

        }
    }

    public void SetClothes(EquipableItemSO item, ItemType itemType)
    {
        if(itemType == ItemType.Clothes)
        {
            itemsEquipped.clothEquipped = item;
            clothesRenderer.runtimeAnimatorController = itemsEquipped.clothEquipped.itemAnimator;
            return;
        }
        if (itemType == ItemType.HeadGear)
        {
            itemsEquipped.headGearEquipped = item;
            headWearRenderer.runtimeAnimatorController = itemsEquipped.headGearEquipped.itemAnimator;
            return;

        }
        if (itemType == ItemType.Hair)
        {
            itemsEquipped.hairEquipped = item;
            headWearRenderer.runtimeAnimatorController = itemsEquipped.hairEquipped.itemAnimator;
            return;

        }

    }

    public void RemoveClothes(ItemType itemType)
    {
        if (itemType == ItemType.Clothes)
        {
            itemsEquipped.clothEquipped = null;
            clothesRenderer.runtimeAnimatorController = null;
            return;
        }
        if (itemType == ItemType.HeadGear)
        {
            itemsEquipped.headGearEquipped = null;
            headWearRenderer.runtimeAnimatorController = itemsEquipped.hairEquipped.itemAnimator;
            return;
        }
    }
}
