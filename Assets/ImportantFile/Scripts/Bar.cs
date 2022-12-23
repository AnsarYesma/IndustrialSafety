using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bar : MonoBehaviour
{
    // Start is called before the first frame update
    public int Direction = 1;
    public bool stall = false;
    public GameObject Mark;
    public GameObject Cross;
    PopUpManager PopUp;
    double fail = 0;
    public Accuracy Data;

    void Start()
    {
        Mark.SetActive(false);
        Cross.SetActive(false);
        transform.position = new Vector3(0, 0, 0);
        PopUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<PopUpManager>();
        PopUp.CallPopUp("Попадите в зеленую зону, нажав SPACE вовремя", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 2.5) {
            Direction = -1;
        }
        if (transform.position.x <= -2.5) {
            Direction = 1;
        }
        if (stall == false) {
            transform.Translate(6f * Direction * Time.deltaTime, 0, 0);
            if (Input.GetKeyDown("space"))
            {
                Debug.Log(transform.position.x);
                if (Mathf.Abs(transform.position.x) > 0.5) {
                    Debug.Log("Fail");
                    fail++;
                    StartCoroutine(Stall());
                } else {
                    Debug.Log("Nice");
                    StartCoroutine(Success());
                }
            }
        }

    }

    IEnumerator Stall() {
        stall = true;
        Cross.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Cross.SetActive(false);
        stall = false;
    }
    IEnumerator Success() {
        stall = true;
        Mark.SetActive(true);
        Data.alcotesterPoints = 1.0 / (fail + 1.0);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SceneWork");
    }
}
