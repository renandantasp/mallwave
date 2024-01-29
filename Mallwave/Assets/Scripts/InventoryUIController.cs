using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    private InventoryPage _inventoryUI;
    
    [SerializeField]
    private int _size;

    [HideInInspector]
    public bool _isInventoryOpen = false;
    
    void Start()
    {
        _inventoryUI.InitializeInventory(_size);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_inventoryUI.isActiveAndEnabled)
            {
                _inventoryUI.Show();
                _isInventoryOpen = true;
            } else
            {
                _inventoryUI.Hide();
                _isInventoryOpen = false;
            }
        }

    }
}
