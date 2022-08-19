using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged Weapon Item Data", menuName = "Item/Ranged Weapon Item Data")]
public class RangedWeaponItemData : ItemData
{
    [Header("Ranged Weapon Data")]
    public float fireRate;
    public GameObject projectilePrefab;
    public ItemData projectileItemData;

    public void Fire(Vector3 spawnPosition, Quaternion spawnRotation, Character.Team team)
    {
        GameObject proj = Instantiate(projectilePrefab, spawnPosition, spawnRotation);
        proj.GetComponent<Projectile>().SetTeam(team);
    }
}
