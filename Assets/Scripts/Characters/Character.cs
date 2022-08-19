using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour, IDamagable
{
    public enum Team
    {
        Player,
        Enemy
    }
    
    public string displayName;
    public int curHp;
    public int maxHp;

    [SerializeField] protected Team team;

    [Header("Audio")] 
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip hitSFX;

    public event UnityAction OnTakeDamage;
    public event UnityAction OnHeal;
    
    public virtual void TakeDamage(int damageToTake)
    {
        curHp -= damageToTake;
        
        audioSource.PlayOneShot(hitSFX);
        
        OnTakeDamage?.Invoke();
        
        if(curHp <=0)
            Die();
    }

    public virtual void Die()
    {
        
    }

    public Team GetTeam()
    {
        return team;
    }

    public virtual void Heal(int healAmount)
    {
        curHp += healAmount;

        if (curHp > maxHp)
            curHp = maxHp;
        
        OnHeal?.Invoke();
    }
}
