using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirx;
    private float dirx2;
    [SerializeField] private float moveSpeed = 7f;

   
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        dirx2 = Input.GetAxis("123");
        rb.velocity = new Vector2(rb.velocity.x, dirx2 * moveSpeed);

        UpdateAnimationUpdate();

    }
        private void UpdateAnimationUpdate()
        {
            if (dirx > 0f)
            {
                anim.SetBool("running", true);
                sprite.flipX = false;
            }
            else if (dirx < 0f)
            {
                anim.SetBool("running", true);
            sprite.flipX = true;
            }
            else if (dirx2 < 0f)
            {
                anim.SetBool("running", true);
            }
            else if (dirx2 > 0f)
            {
                anim.SetBool("running", true);
            }
            else
            {
                anim.SetBool("running", false);
            }








        
                
       


        





    }
}
