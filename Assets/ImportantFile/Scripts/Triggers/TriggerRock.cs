using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

//Код при добычи руды
public class TriggerRock : MonoBehaviour
{
    public LetGo contextOn;
    public LetGo contextOff;
    public bool playerInRange;
    public Accuracy rud;
    public DataForTrigger DataRock;
    private int Rock_number;
    private string Rock_name;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            rud.perforatorPoints++;
            DestroyRock();
            SceneManager.LoadScene("PerforatorMinigame");
        }
    }

    private void DestroyRock()
    {
        Rock_name = gameObject.name;
		Rock_name = new string(Rock_name.Where(x => char.IsDigit(x)).ToArray());
        Rock_number = int.Parse(Rock_name);
        DataRock.DeleteRock = Rock_number;
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


