using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUpManager : MonoBehaviour
{
    public GameObject TextField;
    public GameObject PopUpBlock;
    List<GameObject> Blocks = new List<GameObject>();
    public void CallPopUp(string Message, int t) {
        GetComponent<AudioSource>().Play(0);
        GameObject newPopUp = Instantiate(PopUpBlock, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
        GameObject newTextField = newPopUp.transform.GetChild(0).gameObject;
        for (int i = 0; i < Blocks.Count; ++i) {
            if (Blocks[i] != null)
                Blocks[i].GetComponent<RectTransform>().anchoredPosition = Blocks[i].GetComponent<RectTransform>().anchoredPosition + new Vector2(0, -180);
        }
        Blocks.Add(newPopUp);
        StartCoroutine(Show(Message, newPopUp, newTextField, t));
    }
    public IEnumerator Show(string Message, GameObject PopUpBlock, GameObject TextField, int t) {
        PopUpBlock.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        TextField.GetComponent<TextMeshProUGUI>().text = Message;
        PopUpBlock.SetActive(true);
        yield return new WaitForSeconds(t);
        Destroy(PopUpBlock);
    }
    void Start() {
        PopUpBlock.SetActive(false);
    }
}
