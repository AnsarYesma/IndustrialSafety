using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
using System;

public class Results : MonoBehaviour
{
    public GameObject TextField;
    public Accuracy Data;

    void WriteData()
    {
        string newRow = string.Format("{0},{1},{2},{3}", Data.playerName, Data.alcotesterPoints, Data.firstAidPoints, Data.testPoints);
        File.AppendAllText("Data.csv", newRow + Environment.NewLine);
        Debug.Log(newRow);
    }
    void Start()
    {
        var T = Data.text;
        var L = Data.language;
        string results = Data.playerName + ":\n";
        results += T["Test"][L] + ": " + Data.testPoints.ToString() + "%\n";
        results += T["FirstAid"][L] + ": " + Data.alcotesterPoints.ToString() + " %\n";
        results += T["Alcotester"][L] + ": " + Data.firstAidPoints.ToString() + "%\n";
        GameObject.Find("ButtonText").GetComponent<TextMeshProUGUI>().text = T["ReturnToMain"][L];
        WriteData();
        TextField.GetComponent<TextMeshProUGUI>().text = results;
    }
    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
