using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    Transform player;
    GameManager gm;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().transform;
        gm = GameManager.Instance;
    }

    void Update()
    {
        if( gm.magnet.isActive )
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if( distanceToPlayer < gm.magnet.range )
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * gm.magnet.coinsSpeed;
            }
        }
    }
}
