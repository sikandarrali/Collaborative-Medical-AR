using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

public class ToolbarMaster : MonoBehaviour
{
    public GameObject mainObject;

    //ObjectRotation scriptRotation;
    //ObjectZoom scriptZoom;
    ObjectCut scriptCut;
    SpawnOnTouch scriptBookmark;
    LeanPinchScale scriptZoom;
    Rotation scriptRotation;
    ObjectCutBack scriptCutBack;
    ObjectMaximize scriptMaximize;

    public GameObject Heart_P1, Heart_P2, Heart_P3;

    public GameObject btnPlus, btnRotate, btnZoom, btnCut, btnCutBack, btnMaximize, btnMinimize;

    public Sprite iconPlus, iconCut, iconCutBack, iconRotate, iconZoom, iconMaximize, iconMinimize;
    public Sprite iconPlusBlue, iconCutBlue, iconCutBackBlue, iconRotateBlue, iconZoomBlue;

   // public GameObject zoomSlider;

    public GameObject SpawnOnClick;

    private void Awake()
    {

        SpawnOnClick.SetActive(false);


        //scriptRotation = mainObject.GetComponent<Rotation>();
        //scriptRotation.enabled = false;

        //scriptZoom = mainObject.GetComponent<LeanPinchScale>();
        //scriptZoom.enabled = false;

        btnMinimize.SetActive(false);

        scriptMaximize = mainObject.GetComponent<ObjectMaximize>();
        scriptMaximize.enabled = false;

        //if (PhotonNetwork.IsMasterClient)
        //    btnCut.SetActive(true);
        //else
        //    btnCut.SetActive(false);

    }

    private void Update()
    {
        //if (PhotonNetwork.IsMasterClient)
        //    btnCut.SetActive(true);
        //else
        //    btnCut.SetActive(false);

        if (!SpawnOnClick.activeSelf)
        {
            btnPlus.GetComponent<Image>().sprite = iconPlus;
        }


        if (!PhotonNetwork.IsMasterClient)
        {
            btnRotate.SetActive(false);
            btnZoom.SetActive(false);
            btnMaximize.SetActive(false);
            btnMinimize.SetActive(false);
        }


    }
    /*
    public void onclick_activatecut()
    {
        spawnonclick.setactive(false);
        btnplus.getcomponent<image>().sprite = iconplus;

        scriptrotation.enabled = false;
        btnrotate.getcomponent<image>().sprite = iconrotate;

        scriptzoom.enabled = false;
        btnzoom.getcomponent<image>().sprite = iconzoom;
        //zoomslider.setactive(false);


        scriptcutback.enabled = false;
        btncutback.getcomponent<image>().sprite = iconcutback;

        scriptcut.enabled = true;
        btncut.getcomponent<image>().sprite = iconcutblue;
    

    }
    public void OnClick_deActivateCut()
    {
        SpawnOnClick.SetActive(false);
        btnPlus.GetComponent<Image>().sprite = iconPlus;

        scriptRotation.enabled = false;
        btnRotate.GetComponent<Image>().sprite = iconRotate;

        scriptZoom.enabled = false;
        btnZoom.GetComponent<Image>().sprite = iconZoom;
        //zoomSlider.SetActive(false);

        scriptCut.enabled = false;
        btnCut.GetComponent<Image>().sprite = iconCut;

        scriptCutBack.enabled = true;
        btnCutBack.GetComponent<Image>().sprite = iconCutBackBlue;

    }
    */

    /*
    public void OnClick_ActivateZoom()
    {
        SpawnOnClick.SetActive(false);
        btnPlus.GetComponent<Image>().sprite = iconPlus;

        scriptRotation.enabled = false;
        btnRotate.GetComponent<Image>().sprite = iconRotate;


        ifActive_Maximize();
        //btnMinimize.SetActive(false);
        //btnMaximize.SetActive(true);
        //scriptMaximize.enabled = false;
        //btnMaximize.GetComponent<Image>().sprite = iconMaximize;

        scriptZoom.enabled = true;
        btnZoom.GetComponent<Image>().sprite = iconZoomBlue;
        //zoomSlider.SetActive(true);
    }
    public void OnClick_ActivateRotation()
    {
        SpawnOnClick.SetActive(false);
        btnPlus.GetComponent<Image>().sprite = iconPlus;

        ifActive_Maximize();
//        btnMinimize.SetActive(false);
  //      btnMaximize.SetActive(true);
        //scriptMaximize.enabled = false;
        //btnMaximize.GetComponent<Image>().sprite = iconMaximize;

        scriptZoom.enabled = false;
        btnZoom.GetComponent<Image>().sprite = iconZoom;
        //zoomSlider.SetActive(false);

        scriptRotation.enabled = true;
        btnRotate.GetComponent<Image>().sprite = iconRotateBlue;
    }
    */
    // Object Maximize


    private void ifActive_Maximize()
    {
        if (btnMinimize.activeSelf)
            btnMaximize.SetActive(false);
        if (btnMaximize.activeSelf)
            btnMinimize.SetActive(false);
    }

    public void OnClick_ActivateMaximize()
    {
        SpawnOnClick.SetActive(false);
        btnPlus.GetComponent<Image>().sprite = iconPlus;

        //scriptZoom.enabled = false;
        //btnZoom.GetComponent<Image>().sprite = iconZoom;

        //scriptRotation.enabled = false;
        //btnRotate.GetComponent<Image>().sprite = iconRotate;

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


    public void OnClick_ActivateBookmark()
    {
        //scriptRotation.enabled = false;
        //btnRotate.GetComponent<Image>().sprite = iconRotate;

        ifActive_Maximize();

        //        btnMinimize.SetActive(false);
        //      btnMaximize.SetActive(true);
        //scriptMaximize.enabled = false;
        //btnMaximize.GetComponent<Image>().sprite = iconMaximize;

        //scriptZoom.enabled = false;
        //btnZoom.GetComponent<Image>().sprite = iconZoom;

        SpawnOnClick.SetActive(true);
        btnPlus.GetComponent<Image>().sprite = iconPlusBlue;
    }


}
