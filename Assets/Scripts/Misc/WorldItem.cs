using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private float spawnForce;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip pickupSFX;

    private ItemData _itemToGive;

    private void Start()
    {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        
        rig.AddForce(Random.insideUnitCircle * spawnForce, ForceMode2D.Impulse);
    }

    public void SetItem(ItemData item)
    {
        _itemToGive = item;
        spriteRenderer.sprite = item.icon;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Inventory.Instance.AddItem(_itemToGive);
            AudioManager.Instance.PlayPlayerSound(pickupSFX);
            Destroy(gameObject);
        }
    }
}
