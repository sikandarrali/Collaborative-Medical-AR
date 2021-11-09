using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnOnTouch : MonoBehaviourPunCallbacks
{
    private ExitGames.Client.Photon.Hashtable _BookmarkData = new ExitGames.Client.Photon.Hashtable();
    
    public Color32 playerColor32 = new Color32(0,0,0,0);

    public Vector3 hitpoint = new Vector3(0,0,0);

    public GameObject masterBrain, localBrain, localObjectToSpawn;
    
    public Button btn_AddBookmark, btn_DelBookmark;
    public PhotonView pv;


    public GameObject panel_AddBoomark, ErrorMsg;
    public TMP_InputField input_BookmarkField;

    public string playerName;
    public string playerColor;

    public Vector3 v3_playerColor;

    private void Awake()
    {
        panel_AddBoomark.SetActive(false);
        ErrorMsg.SetActive(false);
    }

    private void Start()
    {
        playerName = PhotonNetwork.LocalPlayer.NickName;
        SetPlayerColor();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                hitpoint = hit.point;

                if (hit.transform.gameObject == masterBrain)
                {
                    panel_AddBoomark.SetActive(true);
                    ErrorMsg.SetActive(false);
                    btn_AddBookmark.onClick.AddListener(SetBookmarkData);//adds a listener for when you click the button
                }
            }
        }
       
    } 

    public void OnClick_CloseBookmarkPanel()
    {
        input_BookmarkField.text = "";
        panel_AddBoomark.SetActive(false);
    }


    public void SetBookmarkData()
    {
        if (input_BookmarkField.text != "")
        {
            ErrorMsg.SetActive(false);
            panel_AddBoomark.SetActive(false);
            pv = GetComponent<PhotonView>();
            pv.RPC("SpawnBookmark", RpcTarget.AllBuffered, playerName, r, g, b, input_BookmarkField.text, hitpoint);
            gameObject.SetActive(false); //disables Add Bookmark button and allows Addition at a time.
        }
        else
        {
            ErrorMsg.SetActive(true);
        }
    }

    [PunRPC]
    public void SpawnBookmark(string getPlayerName, int getR, int getG, int getB, string getBookmarkText, Vector3 getHitPoint)
    {
        //GameObject go = Instantiate(objectToSpawn, getHitPoint, Quaternion.Euler(7f, 0, 0));
        GameObject go = PhotonNetwork.Instantiate("bookmarkSingle", getHitPoint, Quaternion.Euler(7f, 0, 0));
        go.transform.parent = masterBrain.transform;

        // Set Bookmark Text
        Transform t_BookmarkText = go.transform.GetChild(0).GetChild(1).GetChild(1);
        TextMeshProUGUI tmp_BookmarkText = t_BookmarkText.GetComponentInChildren<TextMeshProUGUI>();

        if (tmp_BookmarkText.name == "Text_Bookmark")
            tmp_BookmarkText.text = getBookmarkText;

        

        // Set Player Name
        Transform t_PlayerName = go.transform.GetChild(0).GetChild(1).GetChild(0);
        TextMeshProUGUI tmp_setPlayerName = t_PlayerName.GetComponentInChildren<TextMeshProUGUI>();

        if (tmp_setPlayerName.name == "Text_PlayerName")
            tmp_setPlayerName.text = getPlayerName;


        // Set Player Name Background
        t_PlayerName.GetComponent<RawImage>().color = new Color32((byte)getR, (byte)getG, (byte)getB, 255);

      
        // Set Bookmkark Color
        Transform t_ButtonColor = go.transform.GetChild(0).GetChild(0);
        t_ButtonColor.GetComponent<Image>().color = new Color32((byte)getR, (byte)getG, (byte)getB, 255);

        //go.GetComponent(Renderer).material.color = Color.blue; // or whatever


        Debug.Log("Color: " + PhotonNetwork.LocalPlayer.CustomProperties["playerColor"]);

        // Set Input Field Text to Null after Spawn
        input_BookmarkField.text = "";
    }

    public int r, g, b;
    private void SetPlayerColor()
    {
        // Set Player Color
        System.Random rand = new System.Random();
        
        _BookmarkData["r"] = rand.Next(0, 255);
        _BookmarkData["g"] = rand.Next(0, 255);
        _BookmarkData["b"] = rand.Next(0, 255);
        PhotonNetwork.LocalPlayer.CustomProperties = _BookmarkData;

        r = (int)PhotonNetwork.LocalPlayer.CustomProperties["r"];
        g = (int)PhotonNetwork.LocalPlayer.CustomProperties["g"];
        b = (int)PhotonNetwork.LocalPlayer.CustomProperties["b"];

    }

 }