using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IdentificationManager : MonoBehaviour
{
    public string Username;
    public GameObject NameField;
    public GameObject Mark;
    public Accuracy Data;

    public DataForTrigger HaveData;

    public void Start() {
        var T = Data.text;
        var L = Data.language;
        Mark.SetActive(false);
        GameObject.Find("Ready").GetComponent<TextMeshProUGUI>().text = T["Ready"][L];
        GameObject.Find("Placeholder").GetComponent<TextMeshProUGUI>().text = T["Placeholder"][L];
    }

    IEnumerator Quit() {
        Mark.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SceneWork");
    }

    public void EnterName() {
        Username = NameField.GetComponent<TextMeshProUGUI>().text;
        Data.playerName = Username;
        Debug.Log(Username);
        StartCoroutine(Quit());
    }
}
