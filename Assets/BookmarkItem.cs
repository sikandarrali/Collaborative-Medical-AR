using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class BookmarkItem : MonoBehaviour
{

    // BM = BookMark
    public GameObject btnCloseBM, btnOpenBM, btnDelBM, panelBM;

    public GameObject parentObjectTag;

    public PhotonView parentViewID;

    public TMP_InputField inputFieldBM;

    private void Awake()
    {
        panelBM.SetActive(true);
        btnOpenBM.SetActive(false);
    }

    private void Start()
    {
        parentViewID = gameObject.GetComponentInParent<PhotonView>();
    }

    private void Update()
    {
        parentObjectTag = GameObject.FindGameObjectWithTag("masterBrain");
        //gameObject.transform.SetParent(parentObjectTag.transform);
    }

    public void OnClick_closeBookmark()
    {
        panelBM.SetActive(false);
        btnOpenBM.SetActive(true);
        Debug.Log("Close Bookmark");
    }

    public void OnClick_openBookmark()
    {
        btnOpenBM.SetActive(false);
        panelBM.SetActive(true);
        Debug.Log("Open Bookmark");
    }


}