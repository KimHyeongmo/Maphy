using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class ending_credit : MonoBehaviour
{
    float time_information;
    int time_information_int;

    public TextMeshProUGUI time_words;
    public TextMeshProUGUI grade_words;


    private void Awake()
    {
        time_information = GameObject.Find("Stage_Manager").GetComponent<reset_stage>().end_time;
        time_information_int = (int)time_information;
        save_data();
    }

    private void Start()
    {
        StartCoroutine(words());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            GameObject.Find("Stage_Manager").GetComponent<reset_stage>().end_destory();
        }
    }

    IEnumerator words()
    {
        yield return new WaitForSeconds(2f);

        
        int hour = time_information_int / 3600;
        int minute = (time_information_int - hour * 3600)/60;
        int second = (time_information_int - hour * 3600 - minute * 60);

        string text = "";

        text = text + hour + "시간 " + minute + "분 " + second + "초 ";
        
        foreach (char item in text)
        {
            time_words.text += item;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.0f);

        finish_words();

    }

    void finish_words()
    {
        string text = "Congratulation!!";
        grade_words.text += text;

    }

    void save_data()
    {
        string time_data_path_FULL = "Assets/data/timedata.txt";

        StreamWriter time_data_file;

        if (File.Exists(time_data_path_FULL) == false)
        {
            time_data_file = File.CreateText(time_data_path_FULL);
        }
        else
            time_data_file = File.AppendText(time_data_path_FULL);


        time_data_file.WriteLine(time_information_int);

        time_data_file.Flush();
        time_data_file.Close();
    }
}
