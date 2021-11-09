using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCutBack : MonoBehaviour
{
    public void Update()
    {
        GameObject ChildGameObjectFirstPart = this.transform.GetChild(0).gameObject;
        GameObject ChildGameObjectSecondPart = this.transform.GetChild(1).gameObject;
        GameObject ChildGameObjectMainPart = this.transform.GetChild(2).gameObject;

        ChildGameObjectFirstPart.transform.localPosition = new Vector3(-0.00712257f, -0.009900001f, -0.05078023f);
        ChildGameObjectSecondPart.transform.localPosition = new Vector3(-0.006921931f, -0.03976072f, -0.002945922f);
        ChildGameObjectMainPart.transform.localPosition = new Vector3(-0.005451822f, 0.04279105f, 0.0007544598f);

    }

}
