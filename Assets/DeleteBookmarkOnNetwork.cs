using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBookmarkOnNetwork : MonoBehaviour
{
    public PhotonView pv;
    public void OnClick_delBookmark()
    {
        pv = GetComponent<PhotonView>();
        int id = pv.ViewID;
        int newid = id;
        if(pv.IsMine)
            pv.RPC("delBookmarkOnNetwork", RpcTarget.AllBuffered, newid);
    }

    [PunRPC]
    public void delBookmarkOnNetwork(int deleteID)
    {
        PhotonNetwork.Destroy(PhotonView.Find(deleteID).gameObject);
        //Destroy(PhotonView.Find(deleteID).gameObject);
    }
}
