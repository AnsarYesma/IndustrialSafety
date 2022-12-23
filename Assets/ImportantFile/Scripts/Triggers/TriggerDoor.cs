using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerDoor : MonoBehaviour
{
    public LetGo contextOn;
    public LetGo contextOff;
    public bool playerInRange;

    public GameObject smoke;
    
    PopUpManager popup;

    int t = 0;

    public AudioSource music;

    public DataForTrigger musicoff;

    void Start()
    {
        popup = GameObject.FindGameObjectWithTag("PopUp").GetComponent<PopUpManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && t == 0)
        {
            smoke.SetActive(true);
            StartCoroutine(Clicker());
            musicoff.music = true;
            music.Play();
        }
    }

    public IEnumerator Clicker()
    {
        t = 1;
        popup.CallPopUp("Сообщите об утечке по рации, нажав на 2", 3);
        yield return new WaitForSeconds(3);
        t = 0;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            contextOff.Raise();
            playerInRange = false;
        }
            
    }
}
