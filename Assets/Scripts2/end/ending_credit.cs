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

    Score_Information rank_1;
    int player_rank = 1;

    bool finish_operating = false;

    private void Awake()
    {
        time_information = GameObject.Find("Stage_Manager").GetComponent<reset_stage>().end_time;
        time_information_int = (int)time_information;

        rank_1 = new Score_Information();
        rank_1.time = int.MaxValue;
    }

    private void Start()
    {
        StartCoroutine(words());
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return) && finish_operating)
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

        return_rank();

    }

    void return_rank()
    {
        read_data();

        int hour = rank_1.time / 3600;
        int minute = (rank_1.time - hour * 3600) / 60;
        int second = (rank_1.time - hour * 3600 - minute * 60);

        string tempt = "";

        tempt = tempt + hour + "시간 " + minute + "분 " + second + "초";


        string text = "Your Best Rank : " + tempt + "\n";
        text += "Your Rank : " + player_rank;
        grade_words.text += text;
        save_data();

        finish_operating = true;
    }

    void save_data()
    {

        Score_Information current_score = new Score_Information();

        current_score.time = time_information_int;

        string json = JsonUtility.ToJson(current_score);

        string time_data_path_FULL = Application.streamingAssetsPath + "/timedata.Json";

        StreamWriter writer;
        writer = File.AppendText(time_data_path_FULL);
        writer.WriteLine(json);
        writer.Close();
        //File.WriteAllText(time_data_path_FULL, json);
        


    }

    void read_data()
    {
        //compare data
        string time_data_path_FULL = Application.streamingAssetsPath + "/timedata.Json";

        if(false == File.Exists(time_data_path_FULL))
        {
            StreamWriter sw = File.CreateText(time_data_path_FULL);
            sw.Close();
        }

        StreamReader reader = new StreamReader(time_data_path_FULL);
        string line;
        while((line = reader.ReadLine()) != null)
        {
            compare_data(line);
        }

        if(player_rank == 1)
        {
            rank_1.time = time_information_int;
        }

        reader.Close();
    }

    void compare_data(string json)
    {
        Score_Information score = JsonUtility.FromJson<Score_Information>(json);

        if(score.time <= time_information_int)
        {
            player_rank++;
        }



        //점수가 없다면 에러가능성 존재
        if(score.time < rank_1.time)
        {
            rank_1.time = score.time;
        }
    }
}

public class Score_Information
{
    public int time;
}