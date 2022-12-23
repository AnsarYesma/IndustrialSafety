using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
using System;

public class MainMenu : MonoBehaviour
{
    public Accuracy Data;

    public DataForTrigger DataTrig;

    public void Start()
    {
        var T = Data.text;
        var L = Data.language;
        GameObject.Find("Switch").GetComponent<TextMeshProUGUI>().text = T["SwitchLanguage"][L];
        GameObject.Find("Proceed").GetComponent<TextMeshProUGUI>().text = T["Proceed"][L];
        Data.alcotesterPoints = 0;
        Data.perforatorPoints = 0;
        Data.firstAidPoints = 0;
        Data.testPoints = 0;
        Data.language = 0;
        DataTrig.target = new Vector3(-4.74f, -4.12f, 0);
        DataTrig.target2 = new Vector3(20.2f, 4.39f, 0);
        DataTrig.music = false;
        DataTrig.numdays = -1;
        DataTrig.DeleteRock = -1;
        for (int i = 0; i < DataTrig.page.Length; ++i)
        {
            DataTrig.page[i] = 0;
        }
        for (int i = 0; i < DataTrig.way.Length; ++i)
        {
            DataTrig.way[i] = false;
        }
    }
    public void Proceed()
    {
        //Data.language = 1;
        SceneManager.LoadScene("Days");
    }
    public void Switch()
    {
        Data.language = 1-Data.language;
        var T = Data.text;
        var L = Data.language;
        GameObject.Find("Switch").GetComponent<TextMeshProUGUI>().text = T["SwitchLanguage"][L];
        GameObject.Find("Proceed").GetComponent<TextMeshProUGUI>().text = T["Proceed"][L];
        //SceneManager.LoadScene("");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
