using Inventory;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InventoryUIController inventoryUIController;
    //public Animator clothAnimator, headWearAnimator, playerAnimator;
    
    void Start()
    {
        inventoryUIController = GetComponentInChildren<InventoryUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
