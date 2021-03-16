using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float height;
    public Rigidbody2D rb;
    public bool isground = false;
    public bool facingright = true;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        
        transform.Translate(Vector2.right * x * speed * Time.deltaTime);
        //if (Input.GetKeyDown(KeyCode.Space)&&isground==true) 
        //{
        //    rb.AddForce(Vector2.up * height);
        //    isground = false;
        //}
        if (x > 0.0f && facingright == false)
        {

            flip = false;
        }
        else if (x < 0.0f && facingright == true)
        {
            flip = true;
        }
        if (x == 0)
            anim.SetTrigger("idle");
        else if (x >= 0.1 || x < -0.1)
            anim.SetTrigger("run");
    }
    private void Update()
    {
        // if (x != 0)

        FlipPlayer();
        if (Input.GetKeyDown(KeyCode.Space) && isground == true)
        {

            rb.AddForce(Vector2.up * height);
            anim.SetBool("jump", true);
            isground = false;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("jump", false);
            isground = true;
        }

    }
    bool flip;
    void FlipPlayer()
    {

        facingright = !facingright;
        Vector2 localScale = gameObject.transform.localScale;
        GetComponent<SpriteRenderer>().flipX = flip;
        transform.localScale = localScale;
    }

}
