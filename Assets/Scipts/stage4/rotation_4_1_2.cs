using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_4_1_2 : MonoBehaviour
{
    bool trigger = false;

    float rotation_speed = 30;

    private void FixedUpdate()
    {
        trigger = GetComponentInParent<rotation_4_trigger>().trigger;
        if (trigger == true)
        {
            transform.Rotate(new Vector3(0, 0, Time.fixedDeltaTime * rotation_speed));
        }
    }
}