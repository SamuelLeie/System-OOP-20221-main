using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Text ammoText;

    private void Awake()
    {
        ammoText = GetComponentInChildren<Text>();
    }

    public void SetMaxAmmo(int maxAmmo)
    {
        slider.maxValue = maxAmmo;
        slider.value = maxAmmo;
        ammoText.text = $"{slider.value}/{slider.maxValue}";
    }

    public void SetAmmo(int ammo)
    {
        slider.value = ammo;
        ammoText.text = $"{slider.value}/{slider.maxValue}";
    }
}
