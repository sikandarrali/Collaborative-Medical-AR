using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    float rotationSpeed = 2f;
    private void OnMouseDrag()
    {
        float rotateX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotateY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotateX);
        transform.RotateAround(Vector3.right, rotateY);

    }
}