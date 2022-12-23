using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Анимация Правила
public class AnimUiTAB : MonoBehaviour
{   
    public Transform box;

    public void CloseBox()
    {   
        box.LeanMoveLocalX(-Screen.height * 2, 0.5f).setEaseInExpo();
        Debug.Log(Screen.height);
    }
}
