using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item/Generic Item")]
public class ItemData : ScriptableObject
{
    public string displayName;
    public string description;
    public Sprite icon;

    public int maxStackSize = 1;

    public GameObject equipPrefab;
}
