using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_stage : MonoBehaviour
{

    public GameObject player;

    public GameObject[] prefab;

    int current_stage = 0;

    private void Start()
    {
        Instantiate(prefab[0]).name = "current_stage";
        GameObject.Find("current_stage").SetActive(true);
        Destroy(GameObject.Find("1_stage"));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameObject tempt = Instantiate(prefab[current_stage]);
            tempt.name = "tempt";
            Destroy(GameObject.Find("current_stage"));
            tempt.name = "current_stage";
            tempt.SetActive(true);
            player.transform.position = new Vector3(tempt.transform.position.x, tempt.transform.position.y + 3, tempt.transform.position.z);
        }
    }

    public void stage_change()
    {
        current_stage++;
        GameObject tempt = Instantiate(prefab[current_stage]);
        tempt.name = "tempt";
        Destroy(GameObject.Find("current_stage"));
        tempt.name = "current_stage";
        tempt.SetActive(true);
        player.transform.position = new Vector3(tempt.transform.position.x, tempt.transform.position.y + 3, tempt.transform.position.z);
    }
}
