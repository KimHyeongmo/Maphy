using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_1_1 : MonoBehaviour
{
    SpriteRenderer render_switch;
    public GameObject connecting_door;

    void Awake()
    {
        render_switch = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        change_color();
        open_door();
    }

    void change_color()
    {
        render_switch.color = new Color(255/255f, 127/255f, 127/255f, 1);

    }

    void open_door()
    {
        connecting_door.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        connecting_door.GetComponent<door_1_1>().open = true;
    }
}
