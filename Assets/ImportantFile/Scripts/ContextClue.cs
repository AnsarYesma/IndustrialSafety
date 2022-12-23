using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Активность кнопки. Enable - появление, Disable - пропадание
public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;

    public void Enable()
    {
        contextClue.SetActive(true);
    }

    public void Disable()
    {
        contextClue.SetActive(false);
    }
}
