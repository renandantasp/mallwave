using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Sciptable Objects/Item/Equipable Item")]
    public class EquipableItemSO : ItemSO, IItemAction
    {
        public string ActionName => "Equip";

        public AudioClip ActionSFX {get; private set;}

        public void PerformAction(GameObject character)
        {
            ArmorManager manager = character.GetComponentInParent<ArmorManager>();
            manager.SetClothes(this);

        }
    }
}
