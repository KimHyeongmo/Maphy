using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_2_1 : MonoBehaviour
{
    SpriteRenderer render_switch;
    public GameObject connecting_platform;
    Transform platform_position;
    Color switch_color;
    int move_tag = 0;

    bool enter_flag = false;

    float runTime = 0.0f;

    Vector2 down;
    Vector2 up;

    void Awake()
    {
        render_switch = GetComponent<SpriteRenderer>();
        switch_color = render_switch.color;
        platform_position = connecting_platform.GetComponent<Transform>();
        down = new Vector2(platform_position.position.x, platform_position.position.y);
        up = new Vector2(platform_position.position.x, platform_position.position.y+1.5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ball"))
        {
            Vector2 enter_vector = collision.gameObject.GetComponent<ball>().ball_rigid_property_tempt.velocity_oneframe;
            enter_vector = Vector2.Reflect(enter_vector, collision.contacts[0].normal);
            enter_vector = collision.gameObject.GetComponent<ball>().ball_bounce_rate * (new Vector2(enter_vector.x, enter_vector.y * 0.9f));
            collision.rigidbody.velocity = enter_vector;
        }

        enter_flag = true;
        move_tag = move_tag == 0 ? 1 : 0;
    }

    void Update()
    {
        if (enter_flag == true)
        {
            change_color();
            move_platform();
        }
    }

    void change_color()
    {
        if (move_tag == 1)
        {
            render_switch.color = new Color(255 / 255f, 127 / 255f, 127 / 255f, 1);
            runTime = 0;
        }
        else if(move_tag == 0)
        {
            render_switch.color = switch_color;
            runTime = 0;
        }
    }

    void move_platform()
    {
        if (move_tag == 1)
        {
            while (runTime < 1)
            {
                runTime += 0.05f;

                platform_position.position = Vector2.Lerp(platform_position.position, up, runTime / 1);

                return;
            }
        }
        else if(move_tag == 0)
        {
            while (runTime < 1)
            {
                runTime += 0.05f;

                platform_position.position = Vector2.Lerp(platform_position.position, down, runTime / 1);

                return;
            }
        }
        enter_flag = false;
    }
}
