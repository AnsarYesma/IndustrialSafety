using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
using System;

public class QuestionManager : MonoBehaviour
{
    public int Incorrect = 0;
    public GameObject QuestionBox;
    //public GameObject Score;
    public GameObject Mark;
    public GameObject Cross;
    public GameObject[] OptionsBox;
    public string[,] OptionsText;
    public string[] QuestionText;
    public Accuracy Data;
    public int[] RightAnswer;
    public int CurrrentQuestion = 0;

    void WriteData()
    {
        string newRow = string.Format("{0},{1},{2},{3}", Data.playerName, Data.alcotesterPoints, Data.firstAidPoints, Data.testPoints);
        File.AppendAllText("Data.csv", newRow + Environment.NewLine);
        Debug.Log(newRow);
    }

    IEnumerator NextQuestion() {
        Cross.SetActive(false);
        Mark.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Mark.SetActive(false);
        CurrrentQuestion += 1;
        if (CurrrentQuestion == QuestionText.Length) {
            float Buf = (100f-Incorrect*6.25f);
            Data.testPoints = Buf;
            SceneManager.LoadScene("Results");
        } else {
            QuestionBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestionText[CurrrentQuestion];
            for (int i = 0; i < 3; ++i) {
                OptionsBox[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = OptionsText[CurrrentQuestion, i];
            }
        }
    }
    IEnumerator Wrong() {
        Cross.SetActive(true);
        yield return new WaitForSeconds(2);
        Cross.SetActive(false);
    }
    public void ChooseOption(int i) {   
        Debug.Log(CurrrentQuestion);

        if (i == RightAnswer[CurrrentQuestion]) {
            Debug.Log("Ok");
            StartCoroutine(NextQuestion());
        } else {
            Debug.Log("No");
            Incorrect += 1;
            StartCoroutine(Wrong());
        }
    }

    public void Start() {
        var T = Data.text;
        var L = Data.language;
        OptionsText = new string [,]
        {
            {T["Q11"][L], T["Q12"][L], T["Q13"][L] },
            {T["Q21"][L], T["Q22"][L], T["Q23"][L] },
            {T["Q31"][L], T["Q32"][L], T["Q33"][L] },
            {T["Q41"][L], T["Q42"][L], T["Q43"][L] },
            {T["Q51"][L], T["Q52"][L], T["Q53"][L] },
            {T["Q61"][L], T["Q62"][L], T["Q63"][L] },
            {T["Q71"][L], T["Q72"][L], T["Q73"][L] },
            {T["Q81"][L], T["Q82"][L], T["Q83"][L] }
            
        };
        QuestionText = new string[]
        {
            T["A1"][L],
            T["A2"][L],
            T["A3"][L],
            T["A4"][L],
            T["A5"][L],
            T["A6"][L],
            T["A7"][L],
            T["A8"][L],
        };
        RightAnswer = new int[] { 0, 0, 1, 2, 2, 0, 1, 2 };
        Mark.SetActive(false);
        Cross.SetActive(false);
        QuestionBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestionText[0];
        for (int i = 0; i < 3; ++i) {
            OptionsBox[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = OptionsText[0, i];
        }
    }
}
