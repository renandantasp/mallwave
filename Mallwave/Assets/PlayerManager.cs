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
    [SerializeField]
    private MainMenuManager mainMenu;

    [SerializeField]
    public AnimationVariables AnimVariables;

    [SerializeField]
    private RectTransform mainRectTransform;

    void Start()
    {
        inventoryUIController = GetComponentInChildren<InventoryUIController>();
        playerMovement = GetComponentInChildren<PlayerMovement>();
        mainMenu = GetComponent<MainMenuManager>();

    }

    private void Update()
    {
        if (playerMovement.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainRectTransform.gameObject.SetActive(false);
                DisablePause();
            }

        } else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainRectTransform.gameObject.SetActive(true);
                EnablePause();
            }
        }
    }

    public void ResumeGame()
    {
        mainRectTransform.gameObject.SetActive(false);
        DisablePause();
    }

    public void EnablePause()
    {
        playerMovement.isPaused = true;
    }
    public void DisablePause()
    {
        playerMovement.isPaused = false;
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

public struct AnimationVariables
{
    public bool isWalking;
    public float horizontal, vertical;
}