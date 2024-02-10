using Inventory.Model;
using Unity.Mathematics;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    private bool canInteract;
    public InventorySO shopkeeperInventory;

    public ShopPage shopUI;
    public ShopUIController shopUIController;

    public ShopkeeperPage shopkeeperPage;

    [SerializeField]
    private PlayerManager playerManager;


    void Start()
    {
        canInteract = false;
        shopkeeperPage.Hide();
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

    public void CloseDialog()
    {
        playerManager.DisableTalk();
        shopkeeperPage.Hide();
        shopUI.Hide();
    }

    private void OpenDialog()
    {
        if (shopkeeperPage.Show())
        {
            playerManager.EnableTalk();
        }
    }

    public void OnClickBuy()
    {
        shopkeeperPage.Hide();
        shopUIController.Setup(true);

    }

    public void OnClickSell()
    {
        shopkeeperPage.Hide();
        shopUIController.Setup(false);


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
