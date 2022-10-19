using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forceY = 1;
    Rigidbody2D rb;
    new BoxCollider2D collider;

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
            Physics2D.BoxCast(transform.position, collider.bounds.size, 0f, Vector2.down, 0.1f, 1 << 6);

        bool grounded = hit.collider == null ? false : true;

        if(grounded)
        {
            Debug.Log("Gracz uziemiony");
        }
        else
        {
            Debug.Log("Gracz w powietrzu");
        }
        
        //Debug.DrawLine(transform.position, transform.position + Vector3.down);

        if ( Input.GetMouseButtonDown(0) )
        { 
            rb.AddForce(new Vector2(0, forceY)); 
        }
    }
}
