using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind_force_4_1 : MonoBehaviour
{

    public bool operation = true;
    int power = -300;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (operation == true && (collision.tag == "ball" || collision.tag == "player"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.right * power, ForceMode2D.Force);
        }
    }
}
