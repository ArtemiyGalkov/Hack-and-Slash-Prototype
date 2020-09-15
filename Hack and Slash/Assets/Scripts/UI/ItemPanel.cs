using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public Item Item;
    public int EquipSlot;
    public int Price;
    public bool Inventory;
    public bool InEquipment;
    //public int equipType;
    public bool Barter;
    public bool Buy;
    public bool InCart;

    public void Click()
    {
        if (Barter)
        {
            TransferToCart();
        }
        else if (Inventory)
        {
            ShowEquipWindow();
        }
    }

    public void TransferToCart()
    {
        if (Barter)
        {           
            //AdventureManager.Manager.AdventureMenu.BarterWindow.TransferItem(this, Buy);
        }
    }

    public void ChangeItemPanel(Item item)
    {
        if (item != null)
        {
            Item = item;
            gameObject.GetComponent<Transform>().Find("Name").GetComponent<Text>().text = Item.Name;
            //gameObject.GetComponent<Transform>().Find("Price").GetComponent<Text>().text = "";
            Inventory = true;
            InEquipment = true;
            this.gameObject.SetActive(true);
        }
        else
        {
            Item = null;
            this.gameObject.SetActive(false);
        }
    }

    public void ShowEquipWindow()
    {
        if (Inventory && Item != null)
            ActionManager.Manager.GameMenu.InventoryWindow.equipPanel.Show(this);
    }
}
