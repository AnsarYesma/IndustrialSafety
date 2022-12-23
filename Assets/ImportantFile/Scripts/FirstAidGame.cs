using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstAidGame : MonoBehaviour
{
    AudioSource Rimshot;
    PopUpManager PopUp;
    GameObject Compression;
    GameObject Lungs;
    public Accuracy Data;
    int counter = 0;
    int HandCount = 15;
    int LungCount = 5;
    double MarkerPos = 0;
    double Score = 0;
    List<double> target = new List <double>();
    List<double> hits = new List<double>();

    IEnumerator Quit()
    {
        foreach (var x in hits)
        {
            Score += x;
        }
        Data.firstAidPoints = Score;
        Debug.Log(Score);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Days");
    }
    void Check()
    {
        for (int i = 0; i < target.Count; ++i)
        {
            double pos = target[i];
            double dist = Mathf.Abs((float)(MarkerPos - pos));
            if (dist <= 0.5 && hits[i] == -1)
            {
                hits[i] = 1.5 - dist;
                //GameObject newPoints = Instantiate(Points, new Vector3(0, 0, 0), Quaternion.identity);
                //var scr = newPoints.GetComponent<Points>();
                //Debug.Log(newPoints.transform.position);
                //double xx = hits[i] / 1.5 * 10;
                //scr.Display(xx);
                if (i+1 == target.Count)
                {
                    StartCoroutine(Quit());
                }
                break;
            }
        }
    }

    IEnumerator Tutorial()
    {
        var T = Data.text;
        var L = Data.language;
        yield return new WaitForSeconds(2);
        PopUp.CallPopUp(T["FirstAidTutorial1"][L], 3);
        yield return new WaitForSeconds(2);
        PopUp.CallPopUp(T["FirstAidTutorial2"][L], 3);
        yield return new WaitForSeconds(2);
        PopUp.CallPopUp(T["FirstAidTutorial3"][L], 3);
        yield return new WaitForSeconds(2);
        
        float pos = 11;
        Compression.SetActive(true);
        for (int i = 0; i < HandCount; ++i)
        {
            Instantiate(Compression, new Vector3(pos, 0, 0), Quaternion.identity);
            target.Add(pos);
            hits.Add(-1);
            pos += 3;
        }
        pos += 2.32f;
        Lungs.SetActive(true);
        for (int i = 0; i < LungCount; ++i)
        {
            Instantiate(Lungs, new Vector3(pos, 0, 0), Quaternion.identity);
            target.Add(pos-2.32);
            hits.Add(-1);
            target.Add(pos+2.32);
            hits.Add(-1);
            pos += 3 + 2.32f * 2;
        }
        foreach (var x in target)
        {
            Debug.Log(x);
        }
        MarkerPos = -18+11;
    }
    void Start()
    {
        // Data = Resources.Load<Accuracy>("Accuracy");
        // Data.firstAidPoints = Score;
        Lungs = GameObject.FindGameObjectsWithTag("LungsTag")[0];
        Compression = GameObject.FindGameObjectsWithTag("HandTag")[0];
        //Points = GameObject.FindGameObjectsWithTag("Points")[0];
        Lungs.SetActive(false);
        Compression.SetActive(false);
        Rimshot = gameObject.GetComponent<AudioSource>();
        if (Rimshot == null)
        {
            Rimshot = gameObject.AddComponent<AudioSource>();
            Rimshot.clip = Resources.Load<AudioClip>("Rimshot");
        }
        transform.position = new Vector3(-7, 0, 0);
        transform.localScale = new Vector3(8, 8, 0);
        PopUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<PopUpManager>();
        StartCoroutine(Tutorial());
    }
    void Update()
    {
        MarkerPos += 4f * Time.deltaTime;
        if (transform.localScale.x > 8) {
            transform.localScale -= new Vector3(10f*Time.deltaTime, 10f*Time.deltaTime, 0);
        } else if (transform.localScale.x < 8) {
            transform.localScale = new Vector3(8,8,0);
        }
        if (Input.GetKey("space"))
        {
            transform.localScale = new Vector3(9f, 9f, 0);
        }
        if (Input.GetKeyDown("space"))
        {
            counter++;
            Check();
            Rimshot.Play();
        }
        if (Input.GetKeyUp("space"))
        {
            if (counter > HandCount)
            {
                Check();
            }
            //Rimshot.Play();
        }
    }
}
