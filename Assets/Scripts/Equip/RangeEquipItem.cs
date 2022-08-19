using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEquipItem : EquipItem
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private AudioClip shootSFX;
    private float _lastAttackTime;

    public override void OnUse()
    {
        RangedWeaponItemData i = item as RangedWeaponItemData;
        
        if(Time.time - _lastAttackTime < i.fireRate)
            return;
        
        if(Inventory.Instance.HasItem(i.projectileItemData) == false)
            return;
        
        _lastAttackTime = Time.time;
        
        i.Fire(muzzle.position,muzzle.rotation,Character.Team.Player);
        
        Inventory.Instance.RemoveItem(i.projectileItemData);

        AudioManager.Instance.PlayPlayerSound(shootSFX);
    }
}
