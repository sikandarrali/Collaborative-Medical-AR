using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nav_ClassInfo : MonoBehaviourPunCallbacks
{
    [Header("Class Info Menu")]
    [SerializeField]
    private GameObject closedClassInfo;
    [SerializeField]
    private GameObject openClassInfo;
    [SerializeField]
    private GameObject menuClassInfo;
    [SerializeField]
    private TextMeshProUGUI className;
    [SerializeField]
    private TextMeshProUGUI noOfStudentInClass;
    [SerializeField]
    private TextMeshProUGUI masterClient;

    private int numberOfStudent;

    private void Awake()
    {
        openClassInfo.SetActive(false);
    }

    private void Start()
    {
        className.text = PhotonNetwork.CurrentRoom.Name;
    }

    private void FixedUpdate()
    {
        numberOfStudent = int.Parse((PhotonNetwork.CurrentRoom.PlayerCount).ToString());
        noOfStudentInClass.text = (numberOfStudent-1).ToString();

        masterClient.text = PhotonNetwork.MasterClient.NickName;
    }

    public void OnClick_ShowClassInfo()
    {
        
    }

    public void OnClick_OpenClassInfo()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            closedClassInfo.SetActive(true);
            openClassInfo.SetActive(false);
        }
        else
        {
            closedClassInfo.SetActive(false);
            openClassInfo.SetActive(true);
        }
    }
    public void OnClick_CloseClassInfo()
    {
        closedClassInfo.SetActive(true);
        openClassInfo.SetActive(false);
    }
}