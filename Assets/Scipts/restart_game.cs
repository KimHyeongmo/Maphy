using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_game : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftControl))
        {
            SceneManager.LoadScene("title");
        }
    }
}
