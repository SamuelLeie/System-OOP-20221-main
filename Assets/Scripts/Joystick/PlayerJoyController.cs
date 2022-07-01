using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerJoyController : MonoBehaviour
{
    public FixedJoystick moveJoy;
    public FixedJoystick lookJoy;


    public float speed = 7f;


    void Update()
    {
        UpdateMoveJoystick();
    }

    void UpdateMoveJoystick()
    {
        float ImputX = moveJoy.Horizontal;
        float ImputY = moveJoy.Vertical;

        Vector3 Movement = new Vector3(ImputX, ImputY, 0);
        Movement *= Time.deltaTime * speed;
        transform.Translate(Movement);
    }

    //void UpdateShootJoy()
    //{
    //    if (FixedJoystick.Horizontal >= .2f)
    //    {
    //        horizontalMove = speed;
    //    }
    //    else if (FixedJoystick.Horizontal <= -.2f)
    //    {
    //        horizontalMove = -speed;
    //    }
    //    else
    //    {
    //        horizontalMove = 0f;
    //    }
    //}
}
