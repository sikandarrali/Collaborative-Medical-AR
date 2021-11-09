using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class MedAppManager : MonoBehaviourPunCallbacks
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateOrJoinRoom();
    }

    public void CreateOrJoinRoom()
    {
        string randomClassName = "Class_" + Random.Range(0,100);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;

        //Create Room
        PhotonNetwork.CreateRoom(randomClassName, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " Joined " + PhotonNetwork.CurrentRoom.Name);
        SceneManager.LoadScene("Scene_GamePlay");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("New Player: " + newPlayer.NickName + " Joined " + PhotonNetwork.CurrentRoom.Name);
        SceneManager.LoadScene("Scene_GamePlay");
    }

}
