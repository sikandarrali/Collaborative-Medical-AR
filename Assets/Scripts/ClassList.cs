using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ClassList : MonoBehaviourPunCallbacks
{

    [Header("Lobby UI")]
    public GameObject ui_CreateClass;
    public GameObject ui_JoinClass;

    private bool isEmpty = true;


    [SerializeField]
    private Transform content;

    [SerializeField]
    private SingleClassItem singleClassItem;

    private List<SingleClassItem> _storeClassList = new List<SingleClassItem>();



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach (RoomInfo info in roomList) 
        {

            //Removes Class Name prefab to Class List UI
            if (info.RemovedFromList)
            {
                int index = _storeClassList.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_storeClassList[index].gameObject);
                    _storeClassList.RemoveAt(index);
                }
            }
            //Adds Class Name prefab to Class List UI
            else
            {
                if (!ui_JoinClass.activeSelf)
                {
                    ui_JoinClass.SetActive(true);
                }
                //int index = _storeClassList.FindIndex(x => x.RoomInfo.Name == info.Name);
                //if (index == -1)
                //{
                    SingleClassItem singleItem = Instantiate(singleClassItem, content);
                    if (singleItem != null)
                    {
                        singleItem.SetClassInfo(info);
                        _storeClassList.Add(singleItem);
                    }
                //}
            }
        }
    }



    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + "Disconnected");
        _storeClassList.Clear();
        //PhotonNetwork.DestroyPlayerObjects();



    }
    public override void OnJoinedRoom()
    {
        _storeClassList.Clear();
    }


}
