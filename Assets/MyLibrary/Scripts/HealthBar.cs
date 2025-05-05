using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

   

    public void SetHealth(HealthChangedObject _changed)
    {
     
        slider.value = _changed.currentHealth / (float)_changed.maxHealth;
        Debug.Log(slider.value);
    }
}
