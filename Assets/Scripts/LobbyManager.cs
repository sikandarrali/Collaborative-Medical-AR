using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    [Header("Lobby UI")]
    public GameObject ui_CreateClass;
    public GameObject ui_JoinClass;

    private bool isEmpty = true;

    // Popuplates the Single Class Item
    [SerializeField]
    private Transform content;
    private SingleClassItem singleClassItem;


    private void Start()
    {
       
    }

    private void FixedUpdate()
    {
        //        Debug.Log("Room Name: " + PhotonNetwork.CurrentRoom.Name);



    }

    //Checks Number of Available Rooms
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach (RoomInfo info in roomList)
        {
            Debug.Log("Room Name: " + info.Name);
        }

        Debug.Log("Available Rooms: " + roomList.Count);
        if (roomList.Count == 0)
        {
            Debug.Log("No Rooms Available");
            isEmpty = true;
//            ui_JoinClass.SetActive(false);
//          ui_CreateClass.SetActive(true);
        }
        else
        {
            isEmpty = false;

            //        ui_CreateClass.SetActive(false);
            //      ui_JoinClass.SetActive(true);
        }

    }
    
}