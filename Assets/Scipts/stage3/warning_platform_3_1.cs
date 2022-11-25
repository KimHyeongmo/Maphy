using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning_platform_3_1 : MonoBehaviour
{

    public GameObject resetpoint;
    public GameObject moving_stick;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moving_stick.transform.position = resetpoint.transform.position;
        player.transform.position = new Vector2(resetpoint.transform.position.x,resetpoint.transform.position.y+1);
        if(collision.transform.tag == "ball")
            collision.transform.position = new Vector2(resetpoint.transform.position.x, resetpoint.transform.position.y + 2);
    }
}
