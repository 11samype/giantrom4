using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Transform transform;
    string movement;
    string LEFT = "LEFT";
    string RIGHT = "RIGHT";
    string NONE = "";
    public AudioClip hitSound;
    AudioSource audio;
    bool hitRightSide;
    bool hitLeftSide;

	// Use this for initialization
	void Start ()
    {
        transform = GetComponent<Transform>();
        movement = NONE;
        audio = GetComponent<AudioSource>();
        hitRightSide = false;
        hitLeftSide = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement = LEFT;
            hitRightSide = false;
        } else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movement = NONE;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement = RIGHT;
            hitLeftSide = false;
        } else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            movement = NONE;
        }

        if (movement.Equals(LEFT) && !hitLeftSide)
        {
            transform.Translate(new Vector3(-0.1f, 0, 0));
        }

        if (movement.Equals(RIGHT) && !hitRightSide)
        {
            transform.Translate(new Vector3(0.1f, 0, 0));
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        print(collider.name + ": collision");

        if (collider.name == "target")
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            bool right = contactPoint.x > center.x;
            bool top = contactPoint.y > center.y;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "hazard")
        {
            audio.Play();
        }
        else if (collider.name == "left_bar")
        {
            hitLeftSide = true;
        }
        else if (collider.name == "right_bar")
        {
            hitRightSide = true;
        }
    }


}
