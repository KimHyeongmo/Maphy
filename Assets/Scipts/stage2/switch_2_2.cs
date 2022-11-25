using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_2_2 : MonoBehaviour
{
    SpriteRenderer render_switch;
    public GameObject connecting_door;
    public GameObject connecting_wind_force_area;
    public GameObject connecting_wind_force_platform;

    void Awake()
    {
        render_switch = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        change_color();
        open_door();
        opearation_of_wind_force_aera();
    }

    void change_color()
    {
        render_switch.color = new Color(255 / 255f, 127 / 255f, 127 / 255f, 1);

    }

    void open_door()
    {
        connecting_door.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        connecting_door.GetComponent<door_2_1>().open = true;
    }

    void opearation_of_wind_force_aera()
    {
        connecting_wind_force_area.GetComponent<wind_force_2_1>().operation = true;
        SpriteRenderer[] child = connecting_wind_force_platform.GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer a in child)
        {
            a.enabled = true;
        }
    }
}
