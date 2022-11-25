using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick_platform : MonoBehaviour
{

    Vector2 velocity_of_stick;

    private void Awake()
    {
        velocity_of_stick = GetComponent<Rigidbody2D>().velocity;
    }

    private void FixedUpdate()
    {

        if(velocity_of_stick.magnitude >= 20.0f)
        {
            velocity_of_stick = velocity_of_stick.normalized * 20.0f;
        }
    }

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
