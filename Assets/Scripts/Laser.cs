using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
  
    public LineRenderer lineRenderer;
    

    private void Start()
    {
        DisableLaser();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnableLaser();
        }
        if (Input.GetMouseButton(0))
        {
            UpdateLaser();
        }
        if (Input.GetMouseButtonUp(0))
        {
            DisableLaser();
        }
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;
    }
    void UpdateLaser()
    {

    }
    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
}
