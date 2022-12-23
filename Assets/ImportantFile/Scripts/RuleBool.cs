using UnityEngine;
using System;

public class RuleBool : MonoBehaviour
{
    public DataForTrigger pagedata;
    public GameObject[] pages;
    public GameObject[] locks;
    
    //Снимать замок с книги
    private void OnEnable()
    {
        for (int i = 0; i < pages.Length; ++i)
        {
            if (pagedata.page[i] == 1)
            {
                pages[i].SetActive(true);
                locks[i].SetActive(false);
            }
        }
    }
}
