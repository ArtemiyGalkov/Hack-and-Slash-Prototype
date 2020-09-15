using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public abstract class Unit : MonoBehaviour
{
    public NavMeshAgent agent;

    public int AgroId;

    public float Speed;
    public Vector3 Direction;

    protected bool inMovement;
    protected bool inAttack;

    public string Name;

    public float AttackDistance = 2f;

    public UnitCharacteristics Characteristics;
    public Status Status;

    public abstract Weapon Weapon { get; }
    
    protected void RotateTowardsPoint(Vector3 point)
    {
        //find the vector pointing from our position to the target
        var _direction = (point - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        var _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 1);
    }

    protected float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void EndStrike()
    {
        inAttack = false;
    }

    public void Strike()
    {
        //gameObject.GetComponent<Animator>().ResetTrigger("Attacking");
    }

    public void StartMoving()
    {
        inMovement = true;
        gameObject.GetComponent<Animator>().SetBool("Movement", true);
    }

    public void StopMoving()
    {
        //agent.SetDestination(gameObject.transform.position);
        agent.ResetPath();
        inMovement = false;
        gameObject.GetComponent<Animator>().SetBool("Movement", false);
    }

    public void StopMoving(bool resetDestination)
    {
        if (resetDestination)
            //agent.SetDestination(gameObject.transform.position);
            agent.ResetPath();
        inMovement = false;
        gameObject.GetComponent<Animator>().SetBool("Movement", false);
    }

    protected void InstantlyTurn(Vector3 destination)
    {
        //When on target -> dont rotate!
        if ((destination - transform.position).magnitude < 0.1f) return;

        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * 10);
    }

    public void MoveTowards(Vector3 hit)
    {
        //agent.velocity = new Vector3();
        agent.SetDestination(hit);
        StartMoving();
    }

    public void UpdateCharacteristics()
    {
        //Debug.Log($"{Name} {Characteristics.MoveSpeed} {Characteristics.AttackSpeed}");
        agent.speed = Characteristics.MoveSpeed;
        gameObject.GetComponent<Animator>().SetFloat("AttackSpeed", Characteristics.AttackSpeed);
    }

    public void Attack()
    {
        if (!inAttack)
        {
            StopMoving(true);
            gameObject.GetComponent<Animator>().SetTrigger("Attacking");
            inAttack = true;
        }
    }

    public virtual void Death()
    { 
    }

    public void ReceiveDamage(int damage)
    {
        ActionManager.Manager.ShowUnitText(this, damage.ToString());
        Status.Hp -= damage;

        if (Status.Hp <= 0)
        {
            Death();
        }
    }

    public abstract void Hit();

    public abstract void Hit(Unit unit);
}
