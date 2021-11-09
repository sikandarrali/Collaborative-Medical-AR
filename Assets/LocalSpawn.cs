using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSpawn : MonoBehaviour
{
    public Vector3 hitpoint;
    public GameObject localBrain;
    public GameObject localBookmarkToSpawn;


    private void Update()
    {/*
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                hitpoint = hit.point;

                if (hit.transform.gameObject == localBrain)
                {
                    GameObject go = Instantiate(localBookmarkToSpawn, hitpoint, Quaternion.Euler(7f, 0, 0));
                    go.transform.parent = localBrain.transform;
                    gameObject.SetActive(false);
                }
            }
        }
        */
    }
}
