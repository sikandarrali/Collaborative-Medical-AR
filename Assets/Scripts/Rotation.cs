using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    float rotationSpeed = 2f;

    public void OnMouseDrag()
    {
        float rotateX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotateY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotateX);
        transform.RotateAround(Vector3.right, rotateY);

    }

    /*
    float rotSpeed = 50;
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

                transform.Rotate(Vector3.up, -rotX);
                transform.Rotate(Vector3.right, -rotY);
            }

        }

    }
    */
}


