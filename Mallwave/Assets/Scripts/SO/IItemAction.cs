using UnityEngine;

namespace Inventory.Model
{
    public interface IItemAction
    {
        public AudioClip ActionSFX { get; }

        public void PerformAction(GameObject character);
    }
}
