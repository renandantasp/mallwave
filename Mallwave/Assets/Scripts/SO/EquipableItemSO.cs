using Unity.VisualScripting;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Sciptable Objects/Item/Equipable Item")]
    public class EquipableItemSO : ItemSO, IItemAction
    {
        [field: SerializeField]
        public RuntimeAnimatorController itemAnimator { get; set; }
        public AudioClip ActionSFX { get; private set; }

        [SerializeField]
        private ItemType itemType;

        private bool isEquipped;

        public void Start()
        {
            isEquipped = false;
        }

        public void PerformAction(GameObject character)
        {
            ClothesManager manager = character.GetComponentInParent<ClothesManager>();
            if (!isEquipped)
            {
                manager.SetClothes(this, itemType);
                isEquipped = true;
                CanSell = false;
            } else
            {
                manager.RemoveClothes(itemType);
                isEquipped = false;
                CanSell = true;
            }
        }
    }

    public enum ItemType
    {
        Clothes = 0,
        Hair = 1,
        HeadGear = 2
    }
}
