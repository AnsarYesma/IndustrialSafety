using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Сохранение позиций игрока
public class DataTrans : MonoBehaviour
{
    public PlayerController playerPosition;

    public DataForTrigger transforPosition;

    void Start()
    {
        playerPosition.transform.position = new Vector3(transforPosition.target.x, transforPosition.target.y ,transforPosition.target.z);
    }

    void Update()
    {
        transforPosition.target = playerPosition.transform.position;
    }

    void OnApplicationQuit()
    {
        transforPosition.target = new Vector3(-4.74f, -4.12f, 0);
    }
}
