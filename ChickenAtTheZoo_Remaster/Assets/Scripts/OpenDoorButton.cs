using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour
{

    //button to open the door

    public GameObject door;
    public GameObject button;
    public Sprite usedButton;
    public Sprite openDoor;



    public void OnCollisionEnter2D(Collision2D collision)
    {
        string collTag = collision.gameObject.tag;
        if (collTag.Equals("Player"))
        {
            //change door sprite & delete door collider
            door.transform.Translate(new Vector3(0.8f, 0, 0));
            door.GetComponent<SpriteRenderer>().sprite = openDoor;
            Destroy(door.GetComponent<BoxCollider2D>());

           
            button.GetComponent<SpriteRenderer>().sprite = usedButton;


            Destroy(this.gameObject);

        }
    }
}
