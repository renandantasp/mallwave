using Inventory.Model;
using Inventory.UI;
using System;
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

    public InventoryPage shopUI;

    public ShopkeeperPage shopkeeperPage;

    [SerializeField]
    private PlayerManager playerManager;

    void Start()
    {
        canInteract = false;
        shopkeeperPage.gameObject.SetActive(false);
        shopUI.Hide();


    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown("e"))
        {
            OpenDialog();
        }
        if (canInteract && Input.GetKeyDown("q"))
        {
            CloseDialog();
        }
    }

    private void CloseDialog()
    {
        playerManager.DisableTalk();
        shopkeeperPage.gameObject.SetActive(false);
        shopUI.Hide();
    }

    private void OpenDialog()
    {
        playerManager.EnableTalk();
        shopkeeperPage.gameObject.SetActive(true);
    }

    public void OnClickBuy()
    {
        shopUI.Show();
        shopkeeperPage.gameObject.SetActive(false);

    }

    public void OnClickSell()
    {
        shopUI.Show();
        shopkeeperPage.gameObject.SetActive(false);


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
