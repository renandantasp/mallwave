using Inventory.Model;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{

    public Animator clothesRenderer;

    [SerializeField] 
    private PlayerEquip itemsEquipped;

    public void Start()
    {
        if (itemsEquipped.isClothEquipped())
        {
            clothesRenderer.runtimeAnimatorController = itemsEquipped.clothEquipped.ClothAnimator;

        }
    }

    public void SetClothes(EquipableItemSO item)
    {
        itemsEquipped.clothEquipped = item;
        clothesRenderer.runtimeAnimatorController = itemsEquipped.clothEquipped.ClothAnimator;

    }
}
