using Inventory;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public InventoryUIController inventoryUIController;
    [HideInInspector]
    public PlayerMovement playerMovement;
    //public Animator clothAnimator, headWearAnimator, playerAnimator;
    
    void Start()
    {
        inventoryUIController = GetComponentInChildren<InventoryUIController>();
        playerMovement = GetComponentInChildren<PlayerMovement>();

    }

    public void EnableTalk()
    {
        playerMovement.isTalking = true;
    }
    public void DisableTalk()
    {
        playerMovement.isTalking = false;
    }
}
