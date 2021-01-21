using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMic : MonoBehaviour
{
    private float speed;   //speed is how many units per second we move
    public GameObject player;   //this will hold a link to the player

    // Start is called before the first frame update
    void Start()
    {
        //find the player and store in our player variable
        player = GameObject.FindGameObjectWithTag("Player");

        speed = Random.Range(8f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the object down the screen
        //Vector3.down = 0, -1, 0
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        //Screen Wrapping
        //Check to see if the object has left the bottom edge of the screen
        if (transform.position.y < -9.45f)
        {
            //move the object back to the top edge of the screen but give a new random x coordinate
            MoveToTop();
        }
    }

    void MoveToTop()
    {
        //generate random number
        float randomNumber = Random.Range(-8.25f, 8.25f);
        //make new Vector3 to store the new position we want the object to move to
        Vector3 newPosition = new Vector3(randomNumber, 20f);
        //move object to its new position
        transform.position = newPosition;
        //give object a new random speed
        speed = Random.Range(2f, 4f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //tell the player to check the mic
            player.SendMessage("MicCheck");
        }

        //Check to see if the other object was not a falling object before disappearing
        if (!other.CompareTag("FallingObject"))
        {
            MoveToTop();
        }

    }
}


