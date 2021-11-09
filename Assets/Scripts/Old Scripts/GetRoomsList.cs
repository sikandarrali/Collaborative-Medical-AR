using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRoomsList : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Say Hi");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            Debug.Log("Room Name: " + info.Name);
            Debug.Log("Player Count: " + info.PlayerCount);
            Debug.Log("Max Player: " + info.MaxPlayers);
        }
    }


}
