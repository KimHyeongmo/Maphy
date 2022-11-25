using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_3_1 : MonoBehaviour
{
    public bool open = true;
    public GameObject current_stage;
    public GameObject next_stage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (open == true && collision.transform.tag == "player")
        {
            Debug.Log("clear");
            next_stage.SetActive(true);
            collision.transform.position = new Vector3(next_stage.transform.position.x,next_stage.transform.position.y+3,next_stage.transform.position.z);
            current_stage.SetActive(false);
        }
    }
}
