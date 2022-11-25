using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_title : MonoBehaviour
{
    public ball_rigid_property2 ball_rigid_property_tempt;
    Rigidbody2D ball_rigid;    

    //ball마다의 탄성력
    public float ball_bounce_rate = 1; // default
    //

    public bool handed = false;

    void Awake()
    {
        ball_rigid = GetComponent<Rigidbody2D>();
        ball_rigid_property_tempt = new ball_rigid_property2();
    }

    void Update()
    {
        StartCoroutine(velocity_oneframe_store());
    }

    IEnumerator velocity_oneframe_store()
    {
        yield return null;
        if (ball_rigid != null)
            ball_rigid_property_tempt.velocity_oneframe = ball_rigid.velocity;
    }
}

public class ball_rigid_property2
{
    public float mass, drag, angularDrag, gravityScale;
    public Transform stage_transform;
    public Vector2 velocity_oneframe = new Vector2(1f, 1f);
}