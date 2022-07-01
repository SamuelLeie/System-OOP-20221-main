using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public GameObject Player, weaponSel;
    public PlayerController PC;
    void Awake()
    {
        if(gameObject.GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.1f, 0.1f);
            if (gameObject.transform.parent.transform.parent.tag == "Player")
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Pickup weapon");
            Player = collision.gameObject;
            ChangeItem();
        }
    }
    public void ChangeItem()
    {
        //checks for all child, remember that is there is no child with name "Weapons" it WILL break
        for (int i = 0; i < Player.transform.childCount; i++)
        {
            //if it's weapon
            if (Player.transform.GetChild(i).transform.name == "Weapons")
            {
                //sets PlayerController
                PC = Player.GetComponent<PlayerController>();

                //sets current hitbox to off
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                //gets current weapon and armageddon
                weaponSel = PC.weapons[PC.WeaponIndex].gameObject;
                weaponSel.GetComponent<BoxCollider2D>().enabled = true;

                //gets current weapon and sets it to be an orphan
                weaponSel.transform.SetParent(null);

                //removes current weapon from thingy
                PC.weapons.RemoveAt(PC.WeaponIndex);

                //adds new weapon to thingy
                PC.weapons.Insert(PC.WeaponIndex, gameObject.GetComponent<Weapon>());

                //sets as parent
                gameObject.transform.SetParent(Player.transform.GetChild(i).transform);

                //sets on correct position, at least it's supposed to CURRENTLY BROKEN
                gameObject.transform.position = weaponSel.transform.position;

                //sets correct rotation
                gameObject.transform.rotation = Player.transform.rotation;
                break;
            }
        };
    }
}
