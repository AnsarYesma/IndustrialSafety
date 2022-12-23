using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Загрузка дня
public class CodeDay : MonoBehaviour
{
    public DataForTrigger DataDay;

    public GameObject TextField;

    public Accuracy date;

    List<string> Scenes = new List<string>() { "BusTimeline", "MineMapEccident", "SampleScene 1" };

    private int days;

    void Awake()
    {
        days = DataDay.numdays;
        days = days + 1;
        DataDay.numdays = days;
    }

    void Start()
    {
        DaysLoad();
        StartCoroutine(Quiet());
    }

    private void DaysLoad()
    {
        TextField.GetComponent<TextMeshProUGUI>().text = ("День " + (days + 1).ToString());
    }

    public IEnumerator Quiet()
    {   
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Scenes[days]);
    }
}
