using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    Vector3 MagnetPos;
    public Vector3 initialPosition;
    public int MagnetId;
    PopUpManager PopUp;

    public Accuracy Data;
    private void Start()
    {
        initialPosition = gameObject.transform.position;
        MagnetPos = GameObject.Find("Manager").GetComponent<DressingManager>().Magnets[MagnetId].transform.position;
    }
    void OnMouseDrag()
    {
        //?>>>>
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        // GITHUBCHECK
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        curPosition.z = 0;
        transform.position = curPosition;
        //transform.position.z = 0;
        //transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
    void OnMouseUpAsButton()
    {
        if (Vector3.Distance(transform.position, MagnetPos) < 1)
        {
            transform.position = MagnetPos;
            GameObject old = GameObject.Find("Manager").GetComponent<DressingManager>().Chosen[MagnetId];
            if (old != null)
                old.transform.position = old.GetComponent<OptionManager>().initialPosition;
            GameObject.Find("Manager").GetComponent<DressingManager>().Chosen[MagnetId] = gameObject;
        } else
        {
            GameObject old = GameObject.Find("Manager").GetComponent<DressingManager>().Chosen[MagnetId];
            if (old == gameObject)
                GameObject.Find("Manager").GetComponent<DressingManager>().Chosen[MagnetId] = null;
            transform.position = initialPosition;
        }
    }
}
