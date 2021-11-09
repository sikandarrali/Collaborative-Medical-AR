using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZoom : MonoBehaviour
{

    public float scaleValue = 12f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }

    public void OnSlide_ChangeScale(float newScale)
    {
        scaleValue = newScale;
    }

}
