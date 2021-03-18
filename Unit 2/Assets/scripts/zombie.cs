using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class zombie : MonoBehaviour
{
    public GameObject saliva;
    public Rigidbody2D rb;
    private Animator anim;
    public Rigidbody2D srb;
    public GameObject ThrowFrom;
    bool Throwing = false;
    bool IsThrowing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Throw();
        Projectile();
    }


    void Walk ()
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
    void Throw()
    {
        if(Input.GetKey("space"))
        {
            anim.SetBool("IsThrowing", true);
        }
        else
        {
            anim.SetBool("IsThrowing", false);
        }

    }
    void Projectile()
    {
        Throw();
        IsThrowing = anim.GetBool("IsThrowing");
            if (IsThrowing == true) 
        {
            Throwing = true;
        }
        

        
        if (Throwing == true)
        {
            float sxv = 1000f;
            print("throwing");
            GameObject salivaInstance = Instantiate(saliva, ThrowFrom.transform.position, ThrowFrom.transform.rotation) as GameObject;
            salivaInstance.GetComponent<Rigidbody2D>().AddForce(transform.right * sxv);
            Throwing = false; 
        }

    }


}
