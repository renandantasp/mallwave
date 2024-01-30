using UnityEngine;

namespace Inventory.Model
{
    public interface IItemAction
    {
        public string ActionName { get; }
        public AudioClip ActionSFX { get; }

        public void PerformAction(GameObject character);
    }
}
