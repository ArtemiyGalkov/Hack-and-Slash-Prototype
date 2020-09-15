using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipPanel : MonoBehaviour
{
    public ItemPanel curItem;
    public InventoryWindow InventoryWindow;

    public void Show(ItemPanel item)
    {
        curItem = item;

        gameObject.transform.position = new Vector2(item.transform.position.x, item.transform.position.y - 40);
        gameObject.SetActive(true);

        if (item.InEquipment)
        {
            gameObject.GetComponent<Transform>().Find("EquipButton").gameObject.SetActive(false);
            gameObject.GetComponent<Transform>().Find("UnequipButton").gameObject.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<Transform>().Find("EquipButton").gameObject.SetActive(true);
            gameObject.GetComponent<Transform>().Find("UnequipButton").gameObject.SetActive(false);
        }
    }
    
    public void Unequip()
    {
        ActionManager.Manager.Player.Character.Inventory.Unequip(((Equipment)curItem.Item).Type);
        InventoryWindow.ShowInventory();
        Hide();
    }


    
    public void Equip()
    {
        //Debug.Log(InventoryWindow.gameObject.GetComponent<Transform>().Find("WeaponPanel").GetComponent<ItemPanel>().Item.Name);
        if ((int)((Equipment)curItem.Item).Type < 5)
        {
            ActionManager.Manager.Player.Character.Inventory.ChangeArmor((Equipment)curItem.Item);
        }
        else
        {
            ActionManager.Manager.Player.Character.Inventory.ChangeWeapon((Weapon)curItem.Item);
        }
        InventoryWindow.ShowInventory();
        Hide();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
