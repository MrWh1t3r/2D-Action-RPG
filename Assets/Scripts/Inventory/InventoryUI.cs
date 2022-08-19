using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlotUI[] uiSlots;
    public ItemTooltipUI tooltipUI;

    public void UpdateUI(ItemSlot[] item)
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].SetItemSlot(item[i]);
        }
    }
}
