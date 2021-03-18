using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    private Animator anim;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
    void Walk()
    {
        float xv = 0;
        float yv = 0;
        if (Input.GetKey("w"))
        {
            yv = 10;
        }
        if (Input.GetKey("a"))
        {
            xv = -10;

        }
        if (Input.GetKey("s"))
        {
            yv = -10;
        }
        if (Input.GetKey("d"))
        {
            xv = 10;
        }
        // set the x and y velocity
        rb.velocity = new Vector2(xv, yv);
        if ((xv == 0) && (yv == 0))
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);

        }
    }
}

