using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.Translate(-4f * Time.deltaTime, 0, 0);
            if (transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }
    }
}
