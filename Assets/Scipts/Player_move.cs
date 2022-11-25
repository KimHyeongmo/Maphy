using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public Additional_property player_property;
    Rigidbody2D player_rigid;
    SpriteRenderer player_sprite;
    Animator player_animator;

    void Awake()
    {

        player_rigid = GetComponent<Rigidbody2D>();
        player_property = new Additional_property();
        player_sprite = GetComponent<SpriteRenderer>();
        player_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        player_move_sprite();
        player_jump();
        player_catchball();
    }

    void FixedUpdate()
    {
        player_move_physics();
        ball_scanner();
    }

    void player_catchball()
    {
        if(Input.GetKeyDown(KeyCode.Z) && player_property.handling == 0)
        {
            float short_distance = 2.0f;
            int index_check = 0;
            if (player_property.collider2d.Length > 0)
            {
                for (int i = 0; i < player_property.collider2d.Length; i++)
                {
                    float distance_two_object = Vector2.Distance(player_rigid.position, player_property.collider2d[i].transform.position);
                    if (distance_two_object < short_distance)
                    {
                        short_distance = distance_two_object;
                        index_check = i;
                    }
                }

                player_property.collider2d[index_check].GetComponent<ball>().handed = true;
                                
                player_property.handling = 1;

            }
        }
    }

    void ball_scanner()
    {
        player_property.collider2d = Physics2D.OverlapCircleAll(player_rigid.position, 1.0f, LayerMask.GetMask("ball"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player_landing();
    }

    void player_landing()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(player_rigid.position, Vector3.down, 1);

        if (raycastHit.collider != null)
        {
            player_property.player_jumping = false;
        }
    }

    void player_jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (player_property.player_jumping == false))
        {
            player_rigid.AddForce(Vector2.up * player_property.player_jump_power, ForceMode2D.Impulse);
            player_property.player_jumping = true;
        }
    }

    void player_move_physics()
    {
        if(Input.GetKey(KeyCode.A))
        {
            player_rigid.AddForce(Vector2.right * player_property.player_side_power * -1, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player_rigid.AddForce(Vector2.right * player_property.player_side_power * 1, ForceMode2D.Impulse);
        }


        if(player_rigid.velocity.x > player_property.player_speedright_max)
        {
            player_rigid.velocity = new Vector2(player_property.player_speedright_max, player_rigid.velocity.y);
        }
        else if (player_rigid.velocity.x < player_property.player_speedleft_max)
        {
            player_rigid.velocity = new Vector2(player_property.player_speedleft_max, player_rigid.velocity.y);
        }
    }




    void player_move_sprite()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            player_animator.SetBool("isWalking", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player_sprite.flipX = true;
            player_property.flipX = true;
            player_animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player_sprite.flipX = false;
            player_property.flipX = false;
            player_animator.SetBool("isWalking", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            player_animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            player_animator.SetBool("isWalking", false);
        }

        if(player_property.player_jumping == true)
        {
            player_animator.SetBool("isJumping", true);
        }
        else if(player_property.player_jumping == false)
        {
            player_animator.SetBool("isJumping", false);
        }

    }

}

public class Additional_property
{
    public bool flipX = false; // 우측이 false, 좌측이 true
    public bool current_move; // 현재 움직임 상태. true면 움직이고 있는 것.
    public bool gravityY = false; //true면 위로, false면 아래로

    public bool player_jumping = true;

    public float player_speedright_max = 5;
    public float player_speedleft_max = -5;

    public float player_side_power = 3;
    public float player_jump_power = 10;
    public float player_throwing_power = 20;

    public Collider2D[] collider2d;
    public float handling = 0;
}