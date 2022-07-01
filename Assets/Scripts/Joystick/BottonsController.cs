using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottonsController : MonoBehaviour
{
    public int ChangeWeaponNext;
    public int ChangeWeaponPrev;

    public int selectedWeapon = 0;

    public Button[] buttons;
    public Button exchangeButton;
    public Button reloadButton;
    public Button collectButton;

    public int SelectWeapon1;
    public int SelectWeapon2;



    public List<int> keyList = new List<int>();


    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        foreach (var bt in buttons)
        {
            if (bt.name == "Exchange")
            {
                exchangeButton = bt;
            }
            if (bt.name == "Reload")
            {
                reloadButton = bt;
            }
            if (bt.name == "Collect")
            {
                collectButton = bt;
            }
        }
        //buttons[0].onClick.AddListener(WeaponNext);
        exchangeButton.onClick.AddListener(WeaponNext);
        collectButton.onClick.AddListener(CollectItem);
        reloadButton.onClick.AddListener(CollectItem);

    }

    public void WeaponNext()
    {
        InputController.UIWeaponNext = true;
    }
    public void WeaponPrev()
    {
        InputController.UIWeaponPrev = true;
    }

    public void CollectItem()
    {
        InputController.UICollectItem = true;
    }

    public void ReloadWeapon()
    {
        InputController.UIReloading = true;
    }
}
