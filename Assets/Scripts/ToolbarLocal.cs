using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

public class ToolbarLocal : MonoBehaviour
{
    public GameObject localObject;

   // ObjectRotation scriptRotation;
    //ObjectZoom scriptZoom;

    LeanPinchScale scriptZoom;
    //LocalSpawn scriptAddBookmarkLocal;
    Rotation scriptRotation;

    public GameObject LocalSpawnOB;

    public GameObject Heart_P1, Heart_P2, Heart_P3;

    public GameObject btnRotate, btnZoom, btnPlus, btnMaximize, btnMinimize;

    public Sprite iconRotate, iconZoom, iconPlus;
    public Sprite iconRotateBlue, iconZoomBlue, iconPlusBlue;

    //public GameObject zoomSliderLocal;

    private void Awake()
    {
        LocalSpawnOB.SetActive(false);

      //  scriptRotation = localObject.GetComponent<Rotation>();
    //    scriptRotation.enabled = false;

//        scriptZoom = localObject.GetComponent<LeanPinchScale>();
  //      scriptZoom.enabled = false;


        btnMinimize.SetActive(false);





        //LocalSpawnOB.SetActive(true);
        //zoomSliderLocal.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (!LocalSpawnOB.activeSelf)
        {
            btnPlus.GetComponent<Image>().sprite = iconPlus;
        }
    }

    public void OnClick_LocalActivateRotation()
    {
        scriptZoom.enabled = false;
        btnZoom.GetComponent<Image>().sprite = iconZoom;
        // zoomSliderLocal.SetActive(false);

        LocalSpawnOB.SetActive(false);
        btnPlus.GetComponent<Image>().sprite = iconPlus;

        scriptRotation.enabled = true;
        btnRotate.GetComponent<Image>().sprite = iconRotateBlue;
    }

    public void OnClick_LocalActivateZoom()
    {
        LocalSpawnOB.SetActive(false);
        btnPlus.GetComponent<Image>().sprite = iconPlus;

        scriptRotation.enabled = false;
        btnRotate.GetComponent<Image>().sprite = iconRotate;

        scriptZoom.enabled = true;
        btnZoom.GetComponent<Image>().sprite = iconZoomBlue;
       // zoomSliderLocal.SetActive(true);
    }

    public void OnClick_LocalActivateBookmark()
    {
        scriptRotation.enabled = false;
        btnRotate.GetComponent<Image>().sprite = iconRotate;

        scriptZoom.enabled = false;
        btnZoom.GetComponent<Image>().sprite = iconZoom;
        // zoomSliderLocal.SetActive(true);

        //scriptAddBookmarkLocal.enabled = true;
        LocalSpawnOB.SetActive(true);
        btnPlus.GetComponent<Image>().sprite = iconPlusBlue;


    }


    private void ifActive_Maximize()
    {
        if (btnMinimize.activeSelf)
            btnMaximize.SetActive(false);
        if (btnMaximize.activeSelf)
            btnMinimize.SetActive(false);
    }

    public void OnClick_ActivateMaximize()
    {
        LocalSpawnOB.SetActive(false);
        btnPlus.GetComponent<Image>().sprite = iconPlus;

        scriptZoom.enabled = false;
        btnZoom.GetComponent<Image>().sprite = iconZoom;

        scriptRotation.enabled = false;
        btnRotate.GetComponent<Image>().sprite = iconRotate;

        ifActive_Maximize();

        //        btnMaximize.SetActive(false);
        //      btnMinimize.SetActive(true);
        //scriptMaximize.enabled = true;
        OnClick_Maximize();
        //btnMaximize.GetComponent<Image>().sprite = iconMinimize;
    }

    public void OnClick_Maximize()
    {
        btnMaximize.SetActive(false);
        btnMinimize.SetActive(true);

        Heart_P1.transform.localPosition = new Vector3(-0.00712257f, -0.063f, -0.097f);
        Heart_P2.transform.localPosition = new Vector3(-0.006921931f, -0.145f, 0.060f);
        Heart_P3.transform.localPosition = new Vector3(-0.005451822f, 0.088f, 0.0007544598f);

        Debug.Log("Maximize");

    }

    public void OnClick_Minimize()
    {
        btnMinimize.SetActive(false);
        btnMaximize.SetActive(true);

        Heart_P1.transform.localPosition = new Vector3(-0.00712257f, -0.009900001f, -0.05078023f);
        Heart_P2.transform.localPosition = new Vector3(-0.006921931f, -0.03976072f, -0.002945922f);
        Heart_P3.transform.localPosition = new Vector3(-0.005451822f, 0.04279105f, 0.0007544598f);

        btnMinimize.SetActive(false);
        btnMaximize.SetActive(true);
        Debug.Log("Minimize");
    }

    // Object Maximize Ends





}
