using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Sciptable Objects/Item/Equipable Item")]
    public class EquipableItemSO : ItemSO, IItemAction
    {
        [field: SerializeField]
        public RuntimeAnimatorController ClothAnimator { get; set; }
        public AudioClip ActionSFX {get; private set;}

        public void PerformAction(GameObject character)
        {
            ClothesManager manager = character.GetComponentInParent<ClothesManager>();
            manager.SetClothes(this);
        }
    }
}
