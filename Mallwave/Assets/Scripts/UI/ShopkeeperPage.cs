using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperPage : MonoBehaviour
{
    public UIManager uiManager;
    public bool Show()
    {
        if (!this.uiManager.hasAnyWindowOpen)
        {
            this.uiManager.hasAnyWindowOpen = true;
            this.gameObject.SetActive(true);
            return true;
        }
        return false;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        this.uiManager.hasAnyWindowOpen = false;

    }
}
