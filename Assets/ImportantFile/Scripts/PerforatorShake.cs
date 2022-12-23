using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerforatorShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-4, -2.9f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -4) {
            transform.Translate(-1f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown("space"))
        {
            transform.position = new Vector3(-3.9f, -2.9f, 0);
        }
    }
}
