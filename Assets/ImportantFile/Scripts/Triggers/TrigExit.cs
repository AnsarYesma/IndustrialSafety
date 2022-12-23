using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//такой же код как TriggerTOO но тут есть PopUpManager
public class TrigExit : MonoBehaviour
{

    public LetGo contextOn;
    public LetGo contextOff;
    public bool playerInRange;
    public Accuracy ruda;
    private PopUpManager popUp;
    private int t = 0;

    private void Start()
    {
        popUp = GameObject.FindGameObjectWithTag("PopUp").GetComponent<PopUpManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (ruda.perforatorPoints == 3)
                SceneManager.LoadScene("Days");
            else if (ruda.perforatorPoints < 3 && t == 0)
            {
                StartCoroutine(Clicker());
            }
        }
    }
    
    public IEnumerator Clicker()
    {
        t = 1;
        popUp.CallPopUp("Вы не собрали достаточное количество руды", 5);
        yield return new WaitForSeconds(5);
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
