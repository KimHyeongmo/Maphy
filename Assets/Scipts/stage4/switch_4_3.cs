using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_4_3 : MonoBehaviour
{
    SpriteRenderer render_switch;
    Color switch_color;
    public GameObject connecting_door;
    public GameObject connecting_wind_force_area;

    void Awake()
    {
        render_switch = GetComponent<SpriteRenderer>();
        switch_color = render_switch.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        change_color();
        opearation_enable_platform();
        open_door();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        render_switch.color = switch_color;
        opearation_able_platform();
        closed_door();
    }

    void change_color()
    {
        render_switch.color = new Color(255 / 255f, 127 / 255f, 127 / 255f, 1);
    }

    void opearation_able_platform()
    {
        connecting_wind_force_area.GetComponent<wind_force_4_1>().operation = true;
    }

    void opearation_enable_platform()
    {
        connecting_wind_force_area.GetComponent<wind_force_4_1>().operation = false;
    }


    void open_door()
    {
        connecting_door.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        connecting_door.GetComponent<door_4_1>().open = true;
    }

    void closed_door()
    {
        connecting_door.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        connecting_door.GetComponent<door_4_1>().open = false;
    }
}
