using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public Canvas UI;
    public Component MenuPanel;

    public InventoryWindow InventoryWindow;
    
    public void ShowInventory()
    {
        if (InventoryWindow.gameObject.active)
        {
            InventoryWindow.gameObject.SetActive(false);
        }
        else
        {
            InventoryWindow.ShowInventory();
        }
    }
}