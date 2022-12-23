using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerforatorBar : MonoBehaviour
{
    AudioSource SoundEffect;
    public bool stall = false;
    public GameObject Mark;
    void Start()
    {
        SoundEffect = gameObject.GetComponent<AudioSource>();
        if (SoundEffect == null) {
            SoundEffect = gameObject.AddComponent<AudioSource>();
            SoundEffect.clip = Resources.Load<AudioClip>("perforator");
        }
        Mark.SetActive(false);
        transform.position = new Vector3(5, -3.7f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (stall == false) {
            if (transform.position.y >= 3.7) {
                StartCoroutine(Win());
            } else if (transform.position.y >= -3.7) {
                transform.Translate(4f * Time.deltaTime, 0, 0);
            }
            if (Input.GetKeyDown("space"))
            {
                transform.Translate(-1f, 0, 0);
                SoundEffect.Play();
            }
        }

    }

    IEnumerator Win() {
        stall = true;
        Mark.SetActive(true);
        yield return new WaitForSeconds(3);
        Mark.SetActive(false);
        SceneManager.LoadScene("MineMap");
    }
}
