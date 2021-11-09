using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SwitchView : MonoBehaviourPunCallbacks
{
    public GameObject switchViewButtons;
    public GameObject toolbarLocal, toolbarMaster;
    public GameObject masterView, localView;
    public GameObject btnMasterView, btnLocalView;
    public Sprite spriteMasterView, spriteLocalView;
    public Sprite spriteMasterViewBlue, spriteLocalViewBlue;

    // Start is called before the first frame update
    void Awake()
    {
        localView.SetActive(false);
        switchViewButtons.SetActive(false);

        toolbarLocal.SetActive(false);

        if (!PhotonNetwork.IsMasterClient)
        {
            switchViewButtons.SetActive(true);
        }
        else
        {
            switchViewButtons.SetActive(false);
        }

    }

    private void Update()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            switchViewButtons.SetActive(true);
        }
        else
        {
            switchViewButtons.SetActive(false);
        }
    }

    public void OnClick_SetLocalView()
    {
        masterView.SetActive(false);
        localView.SetActive(true);

        toolbarMaster.SetActive(false);
        toolbarLocal.SetActive(true);

        btnMasterView.GetComponent<Image>().sprite = spriteMasterView;
        btnLocalView.GetComponent<Image>().sprite = spriteLocalViewBlue;       
    }
    public void OnClick_SetMasterView()
    {
        masterView.SetActive(true);
        localView.SetActive(false);

        toolbarMaster.SetActive(true);
        toolbarLocal.SetActive(false);

        btnMasterView.GetComponent<Image>().sprite = spriteMasterViewBlue;
        btnLocalView.GetComponent<Image>().sprite = spriteLocalView;
    }


    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        masterView.SetActive(true);
        localView.SetActive(false);

        toolbarMaster.SetActive(true);
        toolbarLocal.SetActive(false);

    }


}