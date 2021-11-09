using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nav_MainMenu : MonoBehaviourPunCallbacks
{
    [Header("Navigation Menu")]
    [SerializeField]
    private GameObject menuMain;


    [SerializeField]
    private TextMeshProUGUI username;


    private void Awake()
    {
        menuMain.SetActive(false);
    }

    private void Start()
    {
        username.text = PhotonNetwork.LocalPlayer.NickName;
    }

    public void OnClick_ShowMainMenu()
    {
        menuMain.SetActive(true);
    }

    public void OnClick_LeaveClass()
    {
        if (!PhotonNetwork.InRoom)
        {
            Debug.Log("Player Not in Room!");
        }
        else
        {
            PhotonNetwork.LeaveRoom();
            RoomOptions roomOptions = new RoomOptions()
            {
                IsOpen = false
            };
            SceneManager.LoadScene("Scene_Lobby");
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " left room");
    }

    public override void OnLeftRoom()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " Left Room");
    }

    public void OnClick_DisconnetFromServer()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Scene_Login");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " disconnected from Server");
    }


}
