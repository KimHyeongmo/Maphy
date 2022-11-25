using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_4_2 : MonoBehaviour
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

    void opearation_able_platform() //ȸ��ü�� �ΰ��� Ŭ������ �ְ�, �ϳ��� ����� Ŭ������ ���� �ٲ� �������� ��ũ��Ʈ�� ������ �ֵ��� �Ѵ�.
    {
        target.GetComponent<rotation_4_trigger>().trigger = true;
    }

    void opearation_enable_platform()
    {
        target.GetComponent<rotation_4_trigger>().trigger = false;
    }
}
