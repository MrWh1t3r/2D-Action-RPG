using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    private Character.Team _team;
    private Rigidbody2D _rig;

    private void Awake()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        _rig.velocity = transform.up * speed;
    }

    public void SetTeam(Character.Team team)
    {
        _team = team;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        IDamagable damagable = col.gameObject.GetComponent<IDamagable>();

        if (damagable != null && damagable.GetTeam() != _team)
        {
            damagable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
