using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Код который отключает триггеры
public class ManageTrigger : MonoBehaviour
{
    public GameObject[] trigger;
    public DataForTrigger Data;

    public Accuracy date;

    private void OnEnable()
    {
        for (int i = 0; i < trigger.Length; ++i)
        {
            if (Data.way[i])
            {
                trigger[i].SetActive(false);
            }
        }
    }
}
