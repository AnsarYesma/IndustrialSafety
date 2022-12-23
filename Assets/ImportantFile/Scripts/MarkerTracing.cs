using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTracing : MonoBehaviour
{
    // Update is called once per frame
    public GameObject Target;
    void Update()
    {
        float x = Target.transform.position.x;
        float y = Target.transform.position.y;
        transform.localPosition = new Vector3(-57f + (57f*2) * (x-(-6))/30f, 25f + 50f * (y-(6))/(6+8), 0);
    }
}
