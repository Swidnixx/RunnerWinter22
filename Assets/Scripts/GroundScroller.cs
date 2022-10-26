using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float speed = 0.1f;
    public Transform ground1, ground2;

    private void FixedUpdate()
    {
        ground1.position -= new Vector3( speed, 0, 0); 
        ground2.position -= new Vector3( speed, 0, 0); 

        if(ground2.position.x < 0)
        {
            ground1.position += new Vector3( ground1.lossyScale.x * 2, 0, 0);

            var tmp = ground1;
            ground1 = ground2;
            ground2 = tmp;
        }
    }
}
