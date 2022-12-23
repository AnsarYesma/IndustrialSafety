using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Камера следить за передвижением игрока
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float something;

    public Vector2 maxPos;
    public Vector2 minPos;

    private void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y + 1f, -10f);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, something);
        }
    }
}
