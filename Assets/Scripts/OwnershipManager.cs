using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OwnershipManager : MonoBehaviourPun, IPunOwnershipCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (targetView != base.photonView)
            return;
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        if (targetView != base.photonView)
            return;
        Debug.Log("Ownership Transferred");
    }

    public void OnClick_RequestAccess()
    {
        base.photonView.RequestOwnership();
    }

    public void OnClick_ReturnAccessToMaster()
    {
        photonView.TransferOwnership(PhotonNetwork.MasterClient);
        Debug.Log("Returned OwnerName: " + PhotonNetwork.MasterClient.NickName);
    }
}