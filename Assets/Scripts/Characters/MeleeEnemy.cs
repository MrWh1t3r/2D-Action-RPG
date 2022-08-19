using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;

    protected override void AttackTarget()
    {
        IDamagable damagable = Target.GetComponent<IDamagable>();
        
        if (damagable!=null)
            damagable.TakeDamage(damage);
    }

    protected override bool CanAttack()
    {
        return Time.time - LastAttackTime > attackRate;
    }

    protected override bool InAttackRange()
    {
        return TargetDistance <= attackRange;
    }
}