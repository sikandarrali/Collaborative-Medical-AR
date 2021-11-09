using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MySynchronizationScript : MonoBehaviour , IPunObservable
{

    Rigidbody rb;
    PhotonView photonView;

    Vector3 networkPositon;
    Quaternion networkRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();

        //networkPositon = new Vector3();
        networkRotation = new Quaternion();

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            //rb.position = Vector3.MoveTowards(rb.position, networkPositon, Time.fixedDeltaTime);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, networkRotation, Time.fixedDeltaTime * 100);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (photonView.IsMine)
        {
            if (stream.IsWriting)
            {
                //Debug.Log("MasterClient PhotonView");
                // If PhotonView is mine i.e I control the object
                // Sends position, velocity etc.
                // Called on my player on My Player Client

                //stream.SendNext(rb.position);
                stream.SendNext(rb.rotation);


            }
            else
            {
                //Debug.Log("UserClient PhotonView");
                // if Stream is Reading
                // Called on my Player on Remote Player Client 

                //networkPositon = (Vector3)stream.ReceiveNext();
                networkRotation = (Quaternion)stream.ReceiveNext();


            }

        }

    }



}
