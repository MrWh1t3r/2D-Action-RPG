using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public EquipController equipCtrl;
    public static Player Instance;

    private void Awake()
    {
        if(Instance!=null&&Instance!=this)
            Destroy(gameObject);
        else
        {
            Instance = this;
        }
    }

    public override void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
