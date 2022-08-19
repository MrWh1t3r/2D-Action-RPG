using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image healthBarFill;

    private void OnEnable()
    {
        character.OnTakeDamage += UpdateHealthBar;
        character.OnHeal += UpdateHealthBar;
    }

    private void OnDisable()
    {
        character.OnTakeDamage -= UpdateHealthBar;
        character.OnHeal -= UpdateHealthBar;
    }

    private void Start()
    {
        SetNameText(character.displayName);
    }

    void SetNameText(string text)
    {
        nameText.text = text;
    }

    void UpdateHealthBar()
    {
        float healthPercent = (float)character.curHp / (float)character.maxHp;
        healthBarFill.fillAmount = healthPercent;
    }
}
