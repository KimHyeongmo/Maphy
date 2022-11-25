using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : fade
{

    bool multi_issue = false;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Return) && multi_issue == false)
        {
            Fading();
            multi_issue = true;
        }
        if(finish_fading == true)
        {
            StartCoroutine(scene_change());
            
        }
    }

    IEnumerator scene_change()
    {
        finish_fading = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("play");
    }

}
