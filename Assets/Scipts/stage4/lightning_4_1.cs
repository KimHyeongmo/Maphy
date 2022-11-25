using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning_4_1 : MonoBehaviour
{

    public GameObject resetpoint;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
            player.transform.position = new Vector2(resetpoint.transform.position.x, resetpoint.transform.position.y);
    }
}
