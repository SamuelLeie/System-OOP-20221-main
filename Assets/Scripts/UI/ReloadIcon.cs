using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReloadIcon : MonoBehaviour
{
    private Image fill;
    private bool isReloading = false;
    private float ReloadTime = 0;

    private void Awake()
    {
        fill = GetComponentsInChildren<Image>().Where(i => i.type == Image.Type.Filled).First();
    }

    private void Start()
    {
        fill.fillAmount = 0;
    }
    public void StartReload(float reloadTime)
    {
        if(!isReloading)
        {
            ReloadTime = reloadTime;
            fill.fillAmount = 1;
            isReloading = true;
        }
    }

    private void Update()
    {
        if(isReloading)
        {
            fill.fillAmount -= 1 / ReloadTime * Time.deltaTime;

            if(fill.fillAmount <= 0)
            {
                isReloading = false;
                fill.fillAmount = 0;
                ReloadTime = 0;
            }
        }
    }

}
