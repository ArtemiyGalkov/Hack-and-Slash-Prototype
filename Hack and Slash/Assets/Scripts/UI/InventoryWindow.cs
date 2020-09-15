using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    public GameMenu Menu;
    public List<Item> Items;
    public ItemEquipPanel equipPanel;
    public Character Character;

    public void ShowInventory()
    {
        gameObject.SetActive(true);
        Items = new List<Item>();
        Items.AddRange(ActionManager.Manager.Player.Character.Inventory.Items);
        Character = ActionManager.Manager.Player.Character;

        //gameObject.GetComponent<Transform>().Find("MoneyLabel").GetComponent<Text>().text = ActionManager.Manager.Player.Character.Inventory.Money.ToString();

        //Debug.Log(Character.Inventory.Body.Name);

        gameObject.GetComponent<Transform>().Find("WeaponPanel").gameObject.GetComponent<ItemPanel>().ChangeItemPanel(Character.Inventory.Weapon);
        gameObject.GetComponent<Transform>().Find("OffhandPanel").gameObject.GetComponent<ItemPanel>().ChangeItemPanel(Character.Inventory.Offhand);
        gameObject.GetComponent<Transform>().Find("HeadPanel").gameObject.GetComponent<ItemPanel>().ChangeItemPanel(Character.Inventory.Head);
        gameObject.GetComponent<Transform>().Find("BodyPanel").gameObject.GetComponent<ItemPanel>().ChangeItemPanel(Character.Inventory.Body);
        gameObject.GetComponent<Transform>().Find("HandsPanel").gameObject.GetComponent<ItemPanel>().ChangeItemPanel(Character.Inventory.Hands);
        gameObject.GetComponent<Transform>().Find("LegsPanel").gameObject.GetComponent<ItemPanel>().ChangeItemPanel(Character.Inventory.Legs);
        gameObject.GetComponent<Transform>().Find("BootsPanel").gameObject.GetComponent<ItemPanel>().ChangeItemPanel(Character.Inventory.Feet);

        GameObject ScrollView = gameObject.GetComponent<Transform>().Find("ScrollView").gameObject;
        foreach (Transform child in ScrollView.GetComponent<Transform>().Find("Viewport").GetComponent<Transform>().Find("Content").transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        int count = 0;
        foreach (Item item in Items)
        {
            count++;
            GameObject newButton = (GameObject)Instantiate(Resources.Load("UI/ItemPanel"));
            newButton.GetComponent<ItemPanel>().Item = item;
            newButton.GetComponent<ItemPanel>().Inventory = true;
            newButton.GetComponent<Transform>().Find("Name").GetComponent<Text>().text = item.Name;
            //newButton.transform.position = new Vector2(newButton.transform.position.x, 0 + i * -20);
            newButton.transform.SetParent(ScrollView.GetComponent<Transform>().Find("Viewport").GetComponent<Transform>().Find("Content").transform, false);
        }
        ScrollView.GetComponent<Transform>().Find("Viewport").GetComponent<Transform>().Find("Content").GetComponent<RectTransform>().sizeDelta = new Vector2(0, Items.Count * 55);
    }
}
