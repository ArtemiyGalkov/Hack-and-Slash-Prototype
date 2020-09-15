using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : Unit
{
    public Character Character;
    public bool Gender;

    public bool RotateOnAttack = false;
    public Bot Target;

    public override Weapon Weapon
    {
        get
        {
            return Character.Inventory.Weapon;
        }
    }

    public void Start()
    {
        Character = new Character();
        Character.Player = this;

        Character.Inventory = new Inventory();
        Character.Inventory.Character = Character;

        Character.Parameters = new Parameters();
        Characteristics = new UnitCharacteristics(150, 0, 0, 1, 0, 0, 6);
        Status = new Status();

        Character.Inventory.InitializeEquipment();

        Weapon weapon = Data.GetWeapon("Longsword");
        //weapon.Props.HitEffects.Add(new WeaponModificator("extra damage", 10, WeaponModificators.ExtraDamage));
        Character.Inventory.ChangeWeapon(weapon);

        /*Character.Inventory.ChangeArmor(Data.GetArmor("Platemail"));
        Character.Inventory.ChangeArmor(Data.GetArmor("Plate leggins"));
        Character.Inventory.ChangeArmor(Data.GetArmor("Sabatons"));

        Character.Inventory.Items.Add(Data.GetArmor("Boots"));
        Character.Inventory.Items.Add(Data.GetWeapon("Halberd"));
        Character.Inventory.Items.Add(Data.GetArmor("Stockings"));
        Character.Inventory.Items.Add(Data.GetArmor("Rich shoes"));
        Character.Inventory.Items.Add(Data.GetArmor("Simple pants"));
        Character.Inventory.Items.Add(Data.GetArmor("Brigandine"));
        Character.Inventory.Items.Add(Data.GetArmor("Armet"));*/

        Character.Inventory.ChangeArmor(Data.GetArmor("Mercenary armor"));
        Character.Inventory.ChangeArmor(Data.GetArmor("Mercenary pants"));
        Character.Inventory.ChangeArmor(Data.GetArmor("Mercenary hat")); 
        
        Character.Inventory.Items.Add(Data.GetArmor("Platemail"));
        Character.Inventory.Items.Add(Data.GetArmor("Plate leggins"));
        Character.Inventory.Items.Add(Data.GetArmor("Sabatons"));
        Character.Inventory.Items.Add(Data.GetArmor("Armet"));

        UpdateCharacteristics();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 hitPosition;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null &&  !inAttack)
                {
                    if (hit.transform.gameObject.tag == "Terrain")
                    {
                        MoveTowards(hit.point);
                    }
                    else if (hit.transform.gameObject.TryGetComponent(out Bot enemy))
                    {
                        Target = enemy;
                    }
                }
            }
        }

        if (Input.GetMouseButton(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            Target = null;
            if (RotateOnAttack)
                RotateTowadsAttack();
            if (!inAttack)
            {
                RotateTowadsAttack();
                PlayerAttack();
            }
        }

        if (Target != null)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) <= AttackDistance)
            {
                StopMoving(true);
                RotateTowardsPoint(Target.transform.position);
                Target = null;
                Attack();
            }
            else
            {
                MoveTowards(Target.transform.position);
            }
        }
        else if (agent.velocity.x == 0 && agent.velocity.y == 0)
            StopMoving(false);
        else
            InstantlyTurn(agent.destination);
        /*if (inMovement)
            MoveTowards();*/
    }

    public void RotateTowadsAttack()
    {
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1);
        }
    }

    public void PlayerAttack()
    {
        Attack();
    }

    public override void Hit()
    {
        Attack attack = new Attack(this);
    }

    public override void Hit(Unit unit)
    {
        unit.ReceiveDamage(Weapon.CountHitDamage(this, unit));
        foreach (WeaponModificator modificator in this.Weapon.Props.HitEffects)
        {
            modificator.Invoke(this, unit);
        }
    }
}
