using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeBut : MonoBehaviour
{
    public Accuracy but;

    public void Reverse()
    {
        but.firstAidPoints = 0;
        SceneManager.LoadScene("FirstAid");
    }
}
