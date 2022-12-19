using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class reset_stage : MonoBehaviour
{
    public Image Fade_panel;

    public GameObject player;

    public GameObject[] prefab;

    int current_stage = 0;

    float timer;

    public float end_time;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        timer = 0;
    }

    private void Start()
    {
        Instantiate(prefab[0]).name = "current_stage";
        GameObject.Find("current_stage").SetActive(true);
        Destroy(GameObject.Find("1_stage"));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R))
        {
            GameObject tempt = Instantiate(prefab[current_stage]);
            tempt.name = "tempt";
            Destroy(GameObject.Find("current_stage"));
            tempt.name = "current_stage";
            tempt.SetActive(true);
            player.transform.position = new Vector3(tempt.transform.position.x, tempt.transform.position.y + 3, tempt.transform.position.z);
        }

        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftControl))
        {
            SceneManager.LoadScene("title");
            Destroy(gameObject);
        }
    }

    public void end_destory()
    {
        SceneManager.LoadScene("title");
        Destroy(gameObject);
    }

    public void stage_change()
    {
        current_stage++;


        if(current_stage == prefab.Length)
        {
            Destroy(GameObject.Find("Player").GetComponent<Player_move>());
            fade_in();
            StartCoroutine(wait_end());
            end_time = timer;
            return;
        }

        GameObject tempt = Instantiate(prefab[current_stage]);
        tempt.name = "tempt";
        Destroy(GameObject.Find("current_stage"));
        tempt.name = "current_stage";
        tempt.SetActive(true);
        player.transform.position = new Vector3(tempt.transform.position.x, tempt.transform.position.y + 3, tempt.transform.position.z);
    }

    IEnumerator wait_end()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(GameObject.Find("current_stage"));
        SceneManager.LoadScene("end");
        yield return new WaitForSeconds(1f);
        fade_out();
    }

    void fade_in()
    {
        float Fade_time_start = 0f;
        float Fade_time = 1f;

        StartCoroutine(fading_coroutine(Fade_time_start, Fade_time));
    }

    IEnumerator fading_coroutine(float Fade_time_start, float Fade_time)
    {
        Fade_panel.gameObject.SetActive(true);
        Color alpha = Fade_panel.color;
        while (alpha.a < 1f)
        {
            Fade_time_start += Time.deltaTime / Fade_time;
            alpha.a = Mathf.Lerp(0, 1, Fade_time_start);
            Fade_panel.color = alpha;
            yield return null;
        }
        yield return null;
    }

    void fade_out()
    {
        float Fade_time_start = 0f;
        float Fade_time = 1f;

        StartCoroutine(fading_out_coroutine(Fade_time_start, Fade_time));
    }

    IEnumerator fading_out_coroutine(float Fade_time_start, float Fade_time)
    {
        Fade_panel.gameObject.SetActive(true);
        Color alpha = Fade_panel.color;
        while (alpha.a > 0f)
        {
            Fade_time_start += Time.deltaTime / Fade_time;
            alpha.a = Mathf.Lerp(1, 0, Fade_time_start);
            Fade_panel.color = alpha;
            yield return null;
        }
        yield return null;
    }
}
