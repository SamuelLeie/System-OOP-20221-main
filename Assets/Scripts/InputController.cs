using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    static public bool UIWeaponNext;
    static public bool UIWeaponPrev;
    static public bool UICollectItem;
    static public bool UIReloading;

    public int CollectWeapon;
    public int ReloadingWeapon;

    public int FireMouseButton;
    public int ChangeWeaponNext;
    public int ChangeWeaponPrev;

    public int SelectWeapon1;
    public int SelectWeapon2;
    public int SelectWeapon3;
    public int SelectWeapon4;

    public List<int> keyList = new List<int>();

    private void Awake()
    {
        FireMouseButton = 0;
        ChangeWeaponPrev = (int)KeyCode.Q;
        ChangeWeaponNext = (int)KeyCode.E;

        SelectWeapon1 = (int)KeyCode.Alpha1;
        SelectWeapon2 = (int)KeyCode.Alpha2;
        SelectWeapon3 = (int)KeyCode.Alpha3;
        SelectWeapon4 = (int)KeyCode.Alpha4;

        keyList.Add(ChangeWeaponPrev);
        keyList.Add(ChangeWeaponNext);
    }

    private void Update()
    {
        InputState.WeaponNext = false;
        InputState.WeaponPrev = false;
        InputState.SelectWeapon1 = false;
        InputState.SelectWeapon2 = false;
        InputState.SelectWeapon3 = false;
        InputState.SelectWeapon4 = false;

        //if (Input.GetMouseButtonDown(FireMouseButton))
        //{
        //    InputState.FireButton = true;
        //}

        //if(Input.GetMouseButtonUp(FireMouseButton))
        //{
        //    InputState.FireButton = false;
        //}

        if (Input.GetKeyDown((KeyCode)CollectWeapon) || UICollectItem)
        {
            UICollectItem = false;
            InputState.CollectItem = true;
            Debug.Log("PickUp");
            InputState.FireButton = false;
        }

        if (Input.GetKeyDown((KeyCode)ReloadingWeapon) || UIReloading)
        {
            UIReloading = false;
            InputState.ReloadWeapon = true;
            Debug.Log("Reloading...");
            InputState.FireButton = false;
        }

        if (Input.GetKeyDown((KeyCode)ChangeWeaponPrev) || UIWeaponPrev)
        {
            InputState.WeaponPrev = true;
            InputState.FireButton = false;
        }

        if (Input.GetKeyUp((KeyCode)ChangeWeaponPrev))
        {
            InputState.WeaponPrev = false;
        }

        if (Input.GetKeyDown((KeyCode)ChangeWeaponNext) || UIWeaponNext)
        {
            InputState.WeaponNext = true;
            InputState.FireButton = false;
        }

        if (Input.GetKeyUp((KeyCode)ChangeWeaponNext))
        {
            InputState.WeaponNext = false;
        }

        if (Input.GetKeyDown((KeyCode)SelectWeapon1))
        {
            InputState.SelectWeapon1 = true;
            InputState.FireButton = false;
        }

        if (Input.GetKeyUp((KeyCode)SelectWeapon1))
        {
            InputState.SelectWeapon1 = false;
        }

        if (Input.GetKeyDown((KeyCode)SelectWeapon2))
        {
            InputState.SelectWeapon2 = true;
            InputState.FireButton = false;
        }

        if (Input.GetKeyUp((KeyCode)SelectWeapon2))
        {
            InputState.SelectWeapon2 = false;
        }

        if (Input.GetKeyDown((KeyCode)SelectWeapon3))
        {
            InputState.SelectWeapon3 = true;
            InputState.FireButton = false;
        }

        if (Input.GetKeyUp((KeyCode)SelectWeapon3))
        {
            InputState.SelectWeapon3 = false;
        }

        if (Input.GetKeyDown((KeyCode)SelectWeapon4))
        {
            InputState.SelectWeapon4 = true;
            InputState.FireButton = false;
        }

        if (Input.GetKeyUp((KeyCode)SelectWeapon4))
        {
            InputState.SelectWeapon4 = false;
        }

    }
}
