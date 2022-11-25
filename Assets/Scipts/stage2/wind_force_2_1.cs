using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind_force_2_1 : MonoBehaviour
{

    public bool operation = false;
    int upside_power = 60;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (operation == true && (collision.tag == "ball" || collision.tag == "player"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upside_power, ForceMode2D.Force);
        }
    }
}
