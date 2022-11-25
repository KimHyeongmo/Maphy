using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ball"))
        {
            Vector2 enter_vector = collision.gameObject.GetComponent<ball>().ball_rigid_property_tempt.velocity_oneframe;
            enter_vector = Vector2.Reflect(enter_vector, collision.contacts[0].normal);
            enter_vector = collision.gameObject.GetComponent<ball>().ball_bounce_rate * (new Vector2(enter_vector.x, enter_vector.y * 0.9f));
            collision.rigidbody.velocity = enter_vector;
        }
    }
}
