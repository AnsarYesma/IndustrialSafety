using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Сохранение позиций игрока
public class DataTrans1 : MonoBehaviour
{
    public PlayerControllerMine playerPosition;

    public DataForTrigger transforPosition;

    void Start()
    {
        playerPosition.transform.position = new Vector3(transforPosition.target2.x, transforPosition.target2.y ,transforPosition.target2.z);
    }

    void Update()
    {
        transforPosition.target2 = playerPosition.transform.position;
    }

    void OnApplicationQuit()
    {
        transforPosition.target2 = new Vector3(-4.74f, -4.12f, 0);
    }
}
