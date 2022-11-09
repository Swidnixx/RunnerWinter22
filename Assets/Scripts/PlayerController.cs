using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forceY = 1;
    public float fallingSpeed = -1;
    //public float liftingForce = 10;

    Rigidbody2D rb;
    new BoxCollider2D collider;
    bool doubleJumped;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void OnValidate()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, collider.bounds.size);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)(Vector2.down * 0.1f), collider.bounds.size);
    }

    void Update()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(transform.position, collider.bounds.size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));

        bool grounded = hit.collider == null ? false : true;

        if(grounded)
        {
            Debug.Log("Gracz uziemiony");
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            Debug.Log("Gracz w powietrzu");
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        if ( Input.GetMouseButtonDown(0) )
        {
            if ( grounded )
            {
                doubleJumped = false;
                //rb.AddForce(new Vector2(0, forceY));  
                rb.velocity = new Vector2(0, forceY);
            }
            else if(!doubleJumped)
            {
                doubleJumped = true; 
                rb.velocity = new Vector2(0, forceY);
            }
        }

        if( Input.GetMouseButton(0) )
        {
            if(rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(0, fallingSpeed);
                //rb.AddForce(new Vector2(0, Time.deltaTime * -rb.velocity.y * liftingForce));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
