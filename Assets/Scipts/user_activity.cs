using System.Collections;
using System.Collections.Generic;
using UnityEngine;


static class Constants
{
    public const int SLOT_SIZE = 64;
    public const int FIRST_SLOT_LOCATION = 0;
    public const float GRAVITY_SCLAE_DEFAULT = 3;
    public const float BOUNCE_DEFAULT = 1;
    public const float GRAVITY_WHEEL_RATE = 0.25f;
    public const float BOUNCE_WHEEL_RATE = 0.015625f;
}

public class user_activity : MonoBehaviour
{
    /*
     * ability slot 1 : gravity
     * ability slot 2 : bounce
     * 
    */

    //user_inform
    int current_ability_slot = 1;
    float change_gravityscale = Constants.GRAVITY_SCLAE_DEFAULT;
    public float change_bounce_rate = Constants.BOUNCE_DEFAULT;



    //user_script_inform
    RectTransform current_ability_slot_location;
    Transform gravity_gage;
    Transform bounce_gage;
    GameObject Basic_UI;

    RaycastHit2D catching_ball;
    bool catching_TF = false;
    Vector3 past_mouse_position;
    float fixed_update_out_time = 0;
    float fixed_update_time = 1;
    public GameObject player_inform;
    bool catching_able = false;

    float max_catching_speed = 20.0f;
    float max_catching_radius = 6;

    public RectTransform slot_1;
    public RectTransform slot_2;

    // Start is called before the first frame update
    void Awake()
    {
        Basic_UI = GameObject.FindGameObjectWithTag("basic_ui");
        current_ability_slot_location = Basic_UI.transform.Find("ability_slot_icon").GetComponent<RectTransform>();
        //gravity_gage = Basic_UI.transform.Find("Gravity_gage_frame").GetChild(0).transform;
        //bounce_gage = Basic_UI.transform.Find("Bounce_gage_frame").GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        slot_change();
        ability_setting_change();
        physics_change();
        catching_ball_activity_update();
    }

    void FixedUpdate()
    {
        fixed_update_time = Time.time - fixed_update_out_time;
        catching_ball_activity();
        fixed_update_out_time = Time.time;
    }

    void catching_ball_activity_update()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        mouseposition_raw.z = 0 - Camera.main.transform.position.z;
        Vector3 mouseposition_to_objectposition = Camera.main.ScreenToWorldPoint(mouseposition_raw);

        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit2D[] catching_ball_tempt = Physics2D.RaycastAll(mouseposition_to_objectposition, Vector2.zero, 0f);

            if(catching_ball_tempt.Length == 0)
            {
                return;
            }
            for(int i = 0; i < catching_ball_tempt.Length; i++)
            {
                catching_ball = catching_ball_tempt[i];


                if (catching_ball.transform == null)
                {
                    continue;
                }
                else if(catching_ball.transform.tag == "ball")
                {
                    break;
                }
                else if(catching_ball.transform.tag == "stick")
                {
                    break;
                }
            }
            

            //catching_ball = Physics2D.Raycast(mouseposition_to_objectposition, Vector2.zero, 0f);

            if (catching_ball.transform == null)
            {
                return;
            }
            else if(catching_ball.transform.tag != "ball" && catching_ball.transform.tag != "stick")
            {
                return;
            }


            if (Vector2.Distance(player_inform.transform.position, catching_ball.transform.position) <= max_catching_radius)
            {
                catching_able = true;
            }
            else
            {
                catching_able = false;
            }


            if (catching_ball.transform == null || catching_able == false)
            {
                catching_TF = false;
                return;
            }
            else if ((catching_ball.transform.tag == "ball" || catching_ball.transform.tag == "stick") && catching_able == true)
            {
                past_mouse_position = mouseposition_to_objectposition;
                catching_TF = true;
            }
            else
            {
                catching_TF = false;
            }
        }

    }

    void catching_ball_activity()
    {
        if (catching_ball.rigidbody == null)
            return;

        Vector3 mouseposition_raw = Input.mousePosition;
        mouseposition_raw.z = 0 - Camera.main.transform.position.z;
        Vector3 mouseposition_to_objectposition = Camera.main.ScreenToWorldPoint(mouseposition_raw);
        /*
        if (Input.GetMouseButtonDown(0))
        {
            catching_ball = Physics2D.Raycast(mouseposition_to_objectposition, Vector2.zero, 0f);

            if (Vector2.Distance(player_inform.transform.position, catching_ball.transform.position) <= 5) //null처리할 것
            {
                Debug.Log("able"); 
                catching_able = true;
            }
            else
            {
                Debug.Log("disable");
                catching_able = false;
            }
            Debug.Log(catching_ball.transform.tag);

            if (catching_ball.transform == null || catching_able == false)
            {
                Debug.Log("why");

                catching_TF = false;
                return;
            }
            else if (catching_ball.transform.tag == "ball" && catching_able == true)
            {
                Debug.Log("hi2");
                past_mouse_position = mouseposition_to_objectposition;
                catching_TF = true;
            }
        }
        */

        if(Input.GetMouseButton(0) && catching_TF == true)
        {
            if (Vector2.Distance(player_inform.transform.position, catching_ball.transform.position) <= max_catching_radius)
            {
                //catching_ball.rigidbody.velocity = new Vector2(0, 0);
                //catching_ball.transform.position = past_mouse_position;
                Vector2 change_velocity = (mouseposition_to_objectposition - catching_ball.transform.position) / fixed_update_time;
                if(change_velocity.magnitude <= max_catching_speed)
                {
                    catching_ball.rigidbody.velocity = change_velocity;
                }
                else
                {
                    change_velocity = change_velocity.normalized * max_catching_speed;
                    catching_ball.rigidbody.velocity = change_velocity;
                }

            }
            else
            {
                catching_able = false;
            }
        }

        
        if((Input.GetMouseButtonUp(0) && catching_TF == true) || (catching_TF == true && catching_able == false))
        {
            //Vector2 change_velocity = (mouseposition_to_objectposition - past_mouse_position) / fixed_update_time;
            catching_TF = false;
            catching_able = false;
            if(catching_ball.rigidbody.velocity.magnitude <= max_catching_speed)
            {

            }
            else
            {
                catching_ball.rigidbody.velocity = catching_ball.rigidbody.velocity.normalized * max_catching_speed;
            }
            /*
            if (change_velocity.magnitude <= max_catching_speed)
            {
                if (change_velocity.magnitude <= Mathf.Abs(0.1f))
                {

                }
                else
                {
                    catching_ball.rigidbody.velocity = change_velocity;
                }
            }
            else
            {
                if (change_velocity.magnitude <= Mathf.Abs(0.1f))
                {

                }
                else
                {
                    change_velocity = change_velocity.normalized * max_catching_speed;
                    catching_ball.rigidbody.velocity = change_velocity;
                }
            }
            */
        }
        

        past_mouse_position = mouseposition_to_objectposition;
        
    }

    void ability_setting_change()
    {
        Vector2 mouse_wheel_change = Input.mouseScrollDelta;
        if (mouse_wheel_change.y > 0) //위로 스크롤
        {
            if (current_ability_slot == 1)
            {
                if (change_gravityscale > -10)
                {
                    change_gravityscale -= (mouse_wheel_change.y * Constants.GRAVITY_WHEEL_RATE);
                    //gravity_gage.position = new Vector3(gravity_gage.position.x, gravity_gage.position.y + mouse_wheel_change.y * Constants.GRAVITY_WHEEL_RATE * 5, gravity_gage.position.z); //�߷� ���� ���� 5�谡 ������ �ȼ����� �����ǹǷ�
                }
            }
            else if (current_ability_slot == 2)
            {
                if(change_bounce_rate < 1)
                {
                    change_bounce_rate += (mouse_wheel_change.y * Constants.BOUNCE_WHEEL_RATE);
                    //bounce_gage.position = new Vector3(bounce_gage.position.x, bounce_gage.position.y + mouse_wheel_change.y * Constants.BOUNCE_WHEEL_RATE * 60, bounce_gage.position.z);
                }

            }
        }
        else if(mouse_wheel_change.y < 0) //아래로 스크롤
        {
            if(current_ability_slot == 1)
            {
                if (change_gravityscale < 10)
                {
                    change_gravityscale -= (mouse_wheel_change.y * Constants.GRAVITY_WHEEL_RATE);
                    //gravity_gage.position = new Vector3(gravity_gage.position.x, gravity_gage.position.y + mouse_wheel_change.y * Constants.GRAVITY_WHEEL_RATE * 5, gravity_gage.position.z);
                }
            }
            else if(current_ability_slot == 2)
            {
                if (change_bounce_rate > 0)
                {
                    change_bounce_rate += (mouse_wheel_change.y * Constants.BOUNCE_WHEEL_RATE);
                    //bounce_gage.position = new Vector3(bounce_gage.position.x, bounce_gage.position.y + mouse_wheel_change.y * Constants.BOUNCE_WHEEL_RATE * 60, bounce_gage.position.z);
                }
            }
        }
    }

    void physics_change()
    {
        if(Input.GetMouseButtonDown(1))
        {

            Vector3 mouseposition_raw = Input.mousePosition;
            mouseposition_raw.z = 0 - Camera.main.transform.position.z;
            Vector3 mouseposition_to_objectposition = Camera.main.ScreenToWorldPoint(mouseposition_raw);



            RaycastHit2D ball = Physics2D.Raycast(mouseposition_to_objectposition, Vector2.zero, 0f);

            if (ball.transform == null)
            {

            }
            else if(ball.transform.tag == "ball")
            {
                if (current_ability_slot == 1)
                {
                    ball.rigidbody.gravityScale = change_gravityscale;
                }
                else if (current_ability_slot == 2)
                {
                    ball.transform.gameObject.GetComponent<ball>().ball_bounce_rate = change_bounce_rate;
                }
            }
            else if(ball.transform.tag == "stick")
            {
                if(current_ability_slot == 1)
                {
                    ball.rigidbody.gravityScale = change_gravityscale;
                }
                else
                {

                }
            }
            
        }
    }

    void slot_change()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //current_ability_slot_location.position = new Vector3(Constants.FIRST_SLOT_LOCATION + 0 * Constants.SLOT_SIZE, current_ability_slot_location.position.y, current_ability_slot_location.position.z);
            current_ability_slot_location.position = slot_1.position;
            current_ability_slot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //current_ability_slot_location.position = new Vector3(Constants.FIRST_SLOT_LOCATION + 1 * Constants.SLOT_SIZE, current_ability_slot_location.position.y, current_ability_slot_location.position.z);
            current_ability_slot_location.position = slot_2.position;
            current_ability_slot = 2;
        }
    }
}