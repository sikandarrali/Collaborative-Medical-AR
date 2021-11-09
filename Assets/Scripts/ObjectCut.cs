using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCut : MonoBehaviour
{
    public void Update()
    {
        GameObject ChildGameObjectFirstPart = this.transform.GetChild(0).gameObject;
        GameObject ChildGameObjectSecondPart = this.transform.GetChild(1).gameObject;
        GameObject ChildGameObjectMainPart = this.transform.GetChild(2).gameObject;

        ChildGameObjectFirstPart.transform.localPosition = new Vector3(-0.00712257f, -0.063f, -0.097f);
        ChildGameObjectSecondPart.transform.localPosition = new Vector3(-0.006921931f, -0.145f, 0.060f);
        ChildGameObjectMainPart.transform.localPosition = new Vector3(-0.005451822f, 0.088f, 0.0007544598f);


        //   ChildGameObjectSecondPart.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 50, this.transform.position.z);

        // ChildGameObjectMainPart.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 150, this.transform.position.z);

    }
}
