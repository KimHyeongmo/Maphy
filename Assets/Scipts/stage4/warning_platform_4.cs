using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning_platform_4 : MonoBehaviour
{

    public GameObject resetpoint;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = new Vector2(resetpoint.transform.position.x, resetpoint.transform.position.y);
        if (collision.transform.tag == "ball")
            collision.transform.position = new Vector2(resetpoint.transform.position.x, resetpoint.transform.position.y + 2);
    }
}
