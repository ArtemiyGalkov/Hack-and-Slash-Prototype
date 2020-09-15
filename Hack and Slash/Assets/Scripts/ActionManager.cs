using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ActionManager : MonoBehaviour
{
    public static ActionManager Manager;

    public Player Player;

    public Canvas Canvas;
    public GameMenu GameMenu;
    public Text markerRtra;

    void Awake()
    {
        Manager = this;
        SpawnEnemy(Data.GetNPC("Bandit"));
    }
    public void SpawnEnemy(GameObject enemy)
    {
        var unit = GameObject.Instantiate(enemy, new Vector3(-5, 0, 0), enemy.transform.rotation);
        unit.GetComponent<Bot>().Character = enemy.GetComponent<Bot>().Character;
        unit.GetComponent<Bot>().Player = Player.gameObject;
    }

    //List<DamageLbl> damageLbls = new List<DamageLbl>();
    public void ShowUnitText(Unit unit, string text)
    {
        DamageLbl damage = ((GameObject)Resources.Load("UI/DamageLbl")).GetComponent<DamageLbl>();
        damage.unit = unit;
        damage.GetComponent<Text>().text = text;
        GameObject.Instantiate(damage);

        /*Debug.Log($"size = {damageLbls.Count}");
        if (damageLbls.Any(damageLbls => damageLbls.unit == damage.unit))
        {
            Debug.Log(1);
            damage.transform.position = new Vector2(damage.transform.position.x, damage.transform.position.y + 10);
        }
        damageLbls.Add(damage);*/
    }

}
