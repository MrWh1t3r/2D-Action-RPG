using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipItem : MonoBehaviour
{
    [SerializeField] protected ItemData item;

    public virtual void OnUse()
    {
        
    }
}
