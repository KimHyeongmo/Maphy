using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_4_1 : MonoBehaviour
{
    SpriteRenderer render_switch;
    Color switch_color;
    public GameObject target;

    void Awake()
    {
        render_switch = GetComponent<SpriteRenderer>();
        switch_color = render_switch.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        change_color();
        opearation_able_platform();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        render_switch.color = switch_color;
        opearation_enable_platform();
    }

    void change_color()
    {
        render_switch.color = new Color(255 / 255f, 127 / 255f, 127 / 255f, 1);
    }

    void opearation_able_platform()
    {
        SpriteRenderer[] child = target.GetComponentsInChildren<SpriteRenderer>();
        BoxCollider2D[] child2 = target.GetComponentsInChildren<BoxCollider2D>();

        foreach (SpriteRenderer a in child)
        {
            a.enabled = true;
        }
        foreach (BoxCollider2D a in child2)
        {
            a.enabled = true;
        }
    }

    void opearation_enable_platform()
    {
        SpriteRenderer[] child = target.GetComponentsInChildren<SpriteRenderer>();
        BoxCollider2D[] child2 = target.GetComponentsInChildren<BoxCollider2D>();

        foreach (SpriteRenderer a in child)
        {
            a.enabled = false;
        }
        foreach (BoxCollider2D a in child2)
        {
            a.enabled = false;
        }
    }
}
