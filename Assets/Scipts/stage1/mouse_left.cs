using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_left : MonoBehaviour
{
    public GameObject initial_point;
    public GameObject final_point;

    bool tag_return = true;

    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (transform.position != final_point.transform.position && tag_return == true)
        {
            transform.position = Vector2.Lerp(initial_point.transform.position, final_point.transform.position, time);
        }
        else if (tag_return == true)
        {
            tag_return = false;
            StartCoroutine(tag_change());
        }

    }
    IEnumerator tag_change()
    {
        yield return new WaitForSeconds(1.5f);
        transform.position = initial_point.transform.position;
        tag_return = true;
        time = 0;
    }
}
