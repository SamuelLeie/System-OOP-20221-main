using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateJoy : MonoBehaviour
{
    public FixedJoystick lookJoy;
    public PlayerController pc;

    public float horizontalMove = 0f;
    public float runSpeed = 40f;

    private void Update()
    {
        ButtonShoot();
    }

    private void Awake()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    void UpdateLookJoystick()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (lookJoy.Direction != Vector2.zero)
        {
            angle = Mathf.Atan2(lookJoy.Direction.y, lookJoy.Direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
        }
    }

    void ButtonShoot()
    {
        Vector2 v = new Vector2(lookJoy.Horizontal, lookJoy.Vertical);
        if (v.magnitude > 0.8f)
        {
            pc.FireWeapon();
        }
        else
        {
            UpdateLookJoystick();
        }
        //if (Mathf.Abs(lookJoy.Direction) >= .9f)
        //{
        //    pc.FireWeapon();
        //}
        //else
        //{
        //    UpdateLookJoystick();
        //}
    }
}
