using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Sciptable Objects/Item/Base Item")]
    public class ItemSO : ScriptableObject
    {
        public int ID => GetInstanceID();

        [field: SerializeField]
        public bool IsStackable { get; set; }

        [field: SerializeField]
        public string Name { get; set; }

        [field: SerializeField]
        public int Price { get; set; }

        [field: SerializeField]
        [field: TextArea]
        public string Description { get; set; }

        [field: SerializeField]
        public Sprite ItemImage { get; set; }

    }
}