using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class Enemy : Character
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }
    
    protected State CurState;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float chaseDistance;

    [SerializeField] protected ItemData[] dropItems;
    [SerializeField] protected GameObject dropItemPrefab;

    protected GameObject Target;

    protected float LastAttackTime;
    protected float TargetDistance;

    [Header("Components")] 
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        Target = FindObjectOfType<Player>().gameObject;
    }

    protected virtual void Update()
    {
        TargetDistance = Vector2.Distance(transform.position, Target.transform.position);

        spriteRenderer.flipX = GetTargetDirection().x < 0;
        
        switch (CurState)
        {
            case State.Idle: IdleUpdate();
                break;
            case State.Chase: ChaseUpdate();
                break;
            case State.Attack: AttackUpdate();
                break;
            
        }
    }

    void ChangeState(State newState)
    {
        CurState = newState;
    }

    void IdleUpdate()
    {
        if(TargetDistance<=chaseDistance)
            ChangeState(State.Chase);
    }

    void ChaseUpdate()
    {
        if(InAttackRange())
            ChangeState(State.Attack);
        else if(TargetDistance>chaseDistance)
            ChangeState(State.Idle);
        
        transform.position =
            Vector3.MoveTowards(transform.position, Target.transform.position, moveSpeed * Time.deltaTime);
    }

    void AttackUpdate()
    {
        if(TargetDistance>chaseDistance)
            ChangeState(State.Idle);
        else if(!InAttackRange())
            ChangeState(State.Chase);

        if (CanAttack())
        {
            LastAttackTime = Time.time;
            AttackTarget();
        }
        
    }

    protected virtual void AttackTarget()
    {
        
    }

    protected virtual bool CanAttack()
    {
        return false;
    }

    protected virtual bool InAttackRange()
    {
        return false;
    }

    protected Vector2 GetTargetDirection()
    {
        return (Target.transform.position - transform.position).normalized;
    }

    public override void Die()
    {
        DropItems();
        Destroy(gameObject);
    }

    protected void DropItems()
    {
        for (int i = 0; i < dropItems.Length; i++)
        {
            GameObject obj = Instantiate(dropItemPrefab, transform.position, quaternion.identity);
            obj.GetComponent<WorldItem>().SetItem(dropItems[i]);
        }
    }
}
