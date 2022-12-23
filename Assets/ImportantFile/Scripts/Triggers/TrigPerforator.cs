using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigPerforator : MonoBehaviour
{
    public LetGo contextOn;
    public LetGo contextOff;
    public bool playerInRange;

    int t = 0;

    public Accuracy drill;
    
    PopUpManager popup;

    void Start()
    {
        popup = GameObject.FindGameObjectWithTag("PopUp").GetComponent<PopUpManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && t == 0)
        {
            StartCoroutine(Clicker());
        }
    }

    public IEnumerator Clicker()
    {
        t = 1;
        popup.CallPopUp("Перфоратор неисправен. Возращайтесь наверх", 3);
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
