using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3f;

    public Rigidbody2D rb;
    private Vector2 movement;
    
    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    //make the progress bar fill up from 0 with each passing second
    //if the progress is full then the project is over UI comes up
    //if the player reaches and triggers the collider then hold the button to disturb the project

    //there's gonna be a time limit of 1 minute at the left corner of the screen and if it reaches 0 then game over
    

}
