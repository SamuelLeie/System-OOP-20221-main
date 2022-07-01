using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (InputController.UICollectItem)
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
