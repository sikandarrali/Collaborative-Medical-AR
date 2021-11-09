using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitObject : MonoBehaviour
{

    public GameObject[] taurus;

    private void FixedUpdate()
    {
        Debug.Log("x: " + taurus[0].transform.position.x);
        Debug.Log("z: " + taurus[0].transform.position.z);
    }

    public void OnClick_SplitObject()
    {
        float splitOffset = 30f;
        taurus[0].transform.position = new Vector3(transform.position.x - splitOffset, transform.position.y + splitOffset, transform.position.z - splitOffset);
        taurus[1].transform.position = new Vector3(transform.position.x + splitOffset, transform.position.y + splitOffset, transform.position.z - splitOffset);
        taurus[2].transform.position = new Vector3(transform.position.x - splitOffset, transform.position.y - splitOffset, transform.position.z - splitOffset);
        taurus[3].transform.position = new Vector3(transform.position.x + splitOffset, transform.position.y - splitOffset, transform.position.z - splitOffset);
    }

}
