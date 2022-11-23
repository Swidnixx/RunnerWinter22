using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public Transform ground1, ground2;
    public GameObject[] grounds;

    private void FixedUpdate()
    {
        float speed = GameManager.Instance.worldScrollingSpeed;
        ground1.position -= new Vector3( speed, 0, 0); 
        ground2.position -= new Vector3( speed, 0, 0); 

        if(ground2.position.x < 0)
        {
            Destroy(ground1.gameObject);

            int index = Random.Range(0, grounds.Length);
            GameObject newGround = Instantiate(grounds[index]);
            newGround.transform.position = ground2.position 
                + new Vector3(newGround.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0 );

            ground1 = ground2;
            ground2 = newGround.transform;
        }
    }
}
