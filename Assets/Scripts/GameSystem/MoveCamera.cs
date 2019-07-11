using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float speed = 80f;

    private void LateUpdate()
    {
        Vector3 newPos;

        float clampCameraZ;
        float xAxisValue = Input.GetAxis("Horizontal") * speed;

        clampCameraZ = Mathf.Clamp(transform.position.z + (xAxisValue * Time.deltaTime), -70, 80);
        newPos = new Vector3(transform.position.x, transform.position.y, clampCameraZ);

        transform.position = newPos;
    }
}
