using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EquipController : MonoBehaviour
{
    private EquipItem _curEquipItem;
    private GameObject _curEquipObject;
    
    private bool _useInput;

    [Header("Components")]
    [SerializeField] private Transform equipObjectOrigin;
    [SerializeField] private MouseUtilities mouseUtilities;

    
    private void Update()
    {
        Vector2 mouseDir = mouseUtilities.GetMouseDirection(transform.position);

        transform.up = mouseDir;

        if (HasItemEquipped())
        {
            if (_useInput && EventSystem.current.IsPointerOverGameObject() == false)
            {
                _curEquipItem.OnUse();
            }
        }
    }

    public void Equip(ItemData item)
    {
        if(HasItemEquipped())
            UnEquip();

        _curEquipObject = Instantiate(item.equipPrefab, equipObjectOrigin);
        _curEquipItem = _curEquipObject.GetComponent<EquipItem>();
    }

    public void UnEquip()
    {
        if(_curEquipObject!=null)
            Destroy(_curEquipObject);

        _curEquipItem = null;
    }

    public bool HasItemEquipped()
    {
        return _curEquipItem != null;
    }

    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            _useInput = true;
        if (context.phase == InputActionPhase.Canceled)
            _useInput = false;
    }
}
