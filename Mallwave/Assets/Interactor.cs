using Inventory.Model;
using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Interactor : MonoBehaviour
{
    private bool canInteract;
    public InventorySO shopkeeperInventory;

    public InventoryPage inventoryUI;

    public ShopkeeperPage shopkeeperPage;

    void Start()
    {
        canInteract = false;
        shopkeeperPage.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if(canInteract && Input.GetKeyDown("e"))
        {
            DoTheThing();
        }
    }

    private void DoTheThing()
    {
        shopkeeperPage.gameObject.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        canInteract = true;
    }
    void OnTriggerExit2D(Collider2D player)
    {
        canInteract = false;
        shopkeeperPage.gameObject.SetActive(false);

    }
}
