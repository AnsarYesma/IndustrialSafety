using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Код фоновой музыки
public class MusicCode : MonoBehaviour
{
    public MusicCode instance;

    public DataForTrigger music_destroy;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(music_destroy.music)
        {
            Destroy(gameObject);
        }
    }
}
