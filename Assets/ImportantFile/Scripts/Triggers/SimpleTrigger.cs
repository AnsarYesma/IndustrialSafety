using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

//В этом коде идет проверка стоит ли объект в тригере или нет
//Если стоит то мы запускаем функцию contextOn.Raise() в LetGo
//Если не стоит то мы запускаем функцию contextOff.Raise() в LetGo
//{В запуске этих двух есть разница,
//ведь в player есть два кода SignalListener где работают contextOn и contextOff}
public class SimpleTrigger : MonoBehaviour
{
    public LetGo contextOn;
    public LetGo contextOff;
    public bool playerInRange;
    public DataForTrigger data;
    private string str; //Имя триггера на котором стоим

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            str = gameObject.name;
			str = new string(str.Where(x => char.IsDigit(x)).ToArray());
            int sceneNumber = int.Parse(str);
            data.way[sceneNumber] = true;
            SceneManager.LoadScene(data.scene[sceneNumber]);
        }
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
