using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header("Ranged")]
    [SerializeField] private Transform muzzle;
    [SerializeField] private RangedWeaponItemData weapon;
    [SerializeField] private float attackRange;

    protected override void AttackTarget()
    {
        Quaternion projRotation = Quaternion.FromToRotation(transform.up, GetTargetDirection());
        weapon.Fire(muzzle.position, projRotation, team);
    }

    protected override bool CanAttack()
    {
        return Time.time - LastAttackTime > weapon.fireRate;
    }

    protected override bool InAttackRange()
    {
        return TargetDistance <= attackRange;
    }
}
