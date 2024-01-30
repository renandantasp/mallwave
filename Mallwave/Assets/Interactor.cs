using Inventory.Model;
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
        shopkeeperPage.gameObject.SetActive(false);
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
        shopUIController.Setup(true);
        shopkeeperPage.gameObject.SetActive(false);

    }

    public void OnClickSell()
    {
        shopUIController.Setup(false);
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
