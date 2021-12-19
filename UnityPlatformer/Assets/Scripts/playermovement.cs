using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{


    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;


    bool jump = false;

    int speedup = 0;

    int crouch = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedup = 1;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedup = 3;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = 3;
        }
    }
    void FixedUpdate()
    {
        //dkasflkaj
        //move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        if (speedup == 1)
        {
            runSpeed += 10;
            speedup = 0;
        }
        if (speedup == 3)
        {
            runSpeed -= 10;
            speedup = 0;
        }

        if(crouch == 1)
        {
            runSpeed -= 20;
            crouch = 0;
        }
        if (crouch == 3)
        {
            runSpeed += 20;
            crouch = 0;
        }
    }
}
