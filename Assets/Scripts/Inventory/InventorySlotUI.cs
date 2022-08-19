using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private ItemSlot _itemSlot;

    public void SetItemSlot(ItemSlot slot)
    {
        _itemSlot = slot;

        if (slot.Item == null)
        {
            icon.enabled = false;
            quantityText.text = string.Empty;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = slot.Item.icon;
            quantityText.text = slot.Quantity > 1 ? slot.Quantity.ToString() : string.Empty;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_itemSlot.Item!=null)
            Inventory.Instance.UseItem(_itemSlot);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_itemSlot.Item != null)
        {
            Inventory.Instance.UI.tooltipUI.SetTooltip(_itemSlot.Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Inventory.Instance.UI.tooltipUI.DisableTooltip();
    }
}
