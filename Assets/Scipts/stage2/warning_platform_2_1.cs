using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning_platform_2_1 : MonoBehaviour
{

    public GameObject resetpoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = resetpoint.transform.position;
    }
}
