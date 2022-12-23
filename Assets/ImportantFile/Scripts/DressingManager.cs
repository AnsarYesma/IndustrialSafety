using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DressingManager : MonoBehaviour
{
    public GameObject[] Magnets;
    public GameObject[] Chosen;
    public GameObject[] Correct;
    PopUpManager PopUp;
    
    void Start()
    {
        PopUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<PopUpManager>();
    }
    void OnMouseDown()
    {
        //gameObject.GetComponent<Renderer>().enabled = true;
        if (gameObject.GetComponent<Renderer>().enabled == false)
        {
            return;
        }
        for (int i = 0; i < 3; ++i)
        {
            if (Chosen[i] != Correct[i])
            {
                PopUp.CallPopUp("Wrong combination..", 2);
                Debug.Log("BAD");
                foreach (var x in Chosen)
                {
                    x.transform.position = x.GetComponent<OptionManager>().initialPosition;
                }
                for (int j = 0; j < 3; ++j)
                {
                    Chosen[j] = null;
                }
                return;
            }
        }
        PopUp.CallPopUp("Right combination!", 2);
        StartCoroutine(NextScene());
        Debug.Log("GOOD");
    }

    public IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SceneWorkMiner");
    }

    void Update()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        foreach (var x in Chosen)
        {
            if (x == null)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }

        }
    }
}
//THIS IS FOR TESTING 
