using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class JoinOrCreateClass : MonoBehaviourPunCallbacks
{


    [SerializeField]
    private TMP_InputField className;

    // Remove this before final build
    private void Start()
    {
        
    }


    public void OnClick_CreateClass()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;
        roomOptions.CleanupCacheOnLeave = false; //Disable Object Destroying when creator leaves the room
        //Create Room
        PhotonNetwork.JoinOrCreateRoom(className.text, roomOptions, TypedLobby.Default);
    }


    #region Photon Functions
    public override void OnCreatedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name + " Created Successfully!");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("");
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("Scene_ClassRoom");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " Joined " + PhotonNetwork.CurrentRoom.Name);
    }

    #endregion
    



}
