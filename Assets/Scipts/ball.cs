using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public ball_rigid_property ball_rigid_property_tempt;
    Rigidbody2D ball_rigid;    
    Player_move player_script;
    GameObject player_hand;

    public bool catching_able = false;

    //ball마다의 탄성력
    public float ball_bounce_rate = 1; // default
    //

    public bool handed = false;

    void Awake()
    {
        ball_rigid = GetComponent<Rigidbody2D>();
        ball_rigid_property_tempt = new ball_rigid_property();
        player_script = GameObject.FindGameObjectWithTag("player").GetComponent<Player_move>();
        player_hand = GameObject.FindGameObjectWithTag("player_hand");
    }

    void Update()
    {
        if (player_script.player_property.handling == 1 && handed == true)
        {
            property_store();
            Destroy(ball_rigid);
            transform.SetParent(player_hand.transform);
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            player_script.player_property.handling = 2;
        }

        if (player_script.player_property.handling == 2 && Input.GetKeyDown(KeyCode.LeftControl) && handed == true)
        {
            transform.SetParent(ball_rigid_property_tempt.stage_transform);
            player_script.player_property.handling = 0;
            gameObject.AddComponent<Rigidbody2D>();
            ball_rigid = GetComponent<Rigidbody2D>();
            property_load();
            ball_rigid.AddForce(Vector2.right * (player_script.player_property.flipX == true ? -1 : 1) * player_script.player_property.player_throwing_power, ForceMode2D.Impulse);
            handed = false;
        }

        StartCoroutine(velocity_oneframe_store());
    }

    IEnumerator velocity_oneframe_store()
    {
        yield return null;
        if (ball_rigid != null)
        {
            ball_rigid_property_tempt.velocity_oneframe = ball_rigid.velocity;
        }
    }

    public void property_store()
    {
        ball_rigid_property_tempt.mass = ball_rigid.mass;
        ball_rigid_property_tempt.drag = ball_rigid.drag;
        ball_rigid_property_tempt.angularDrag = ball_rigid.angularDrag;
        ball_rigid_property_tempt.gravityScale = ball_rigid.gravityScale;
        ball_rigid_property_tempt.stage_transform = transform.parent;
    }

    public void property_load()
    {
        ball_rigid.mass = ball_rigid_property_tempt.mass;
        ball_rigid.drag = ball_rigid_property_tempt.drag;
        ball_rigid.gravityScale = ball_rigid_property_tempt.gravityScale;
        ball_rigid.angularDrag = ball_rigid_property_tempt.angularDrag;
    }
}

public class ball_rigid_property
{
    public float mass, drag, angularDrag, gravityScale;
    public Transform stage_transform;
    public Vector2 velocity_oneframe = new Vector2(1f, 1f);
}