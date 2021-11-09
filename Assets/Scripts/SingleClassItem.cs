using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SingleClassItem : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI className;
    
    public RoomInfo RoomInfo { get; private set; }

    public void SetClassInfo (RoomInfo classInfo)
    {
        RoomInfo = classInfo;
        className.text = classInfo.Name;
    }

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(className.text);
    }


}
