using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Net;
using System.IO;
using UnityEngine.SceneManagement;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    [Header("Login UI")]
    public TMP_InputField playerName_InputField;

    [Header("Lobby UI")]
    public GameObject ui_base;
    public GameObject ui_splashScreen;
    public GameObject ui_connectionFailed;
    public GameObject ui_joinClass;
    public TextMeshProUGUI text_connectionStatus;

    // keep UI_Base & UI_SplashScreen Active in Editor

    #region UnityMethods
    private void Awake()
    {
        ui_base.SetActive(true);
        ui_splashScreen.SetActive(true);

        ui_connectionFailed.SetActive(false);
        ui_joinClass.SetActive(false);
    }

    void Start()
    {

        if (isConnectedToInternet())
        {
            ui_connectionFailed.SetActive(false);
            ui_splashScreen.SetActive(false);
            ui_joinClass.SetActive(true);
        }
        else
        {
            ui_splashScreen.SetActive(false);
            ui_joinClass.SetActive(false);
            ui_connectionFailed.SetActive(true);
        }

    }

    void Update()
    {
        text_connectionStatus.text = PhotonNetwork.NetworkClientState.ToString();
    }
    #endregion

    

    #region UI CallBacks
    public void OnClick_UserLogin()
    {
        string playerName = playerName_InputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            if (!PhotonNetwork.IsConnected)
            {
                ui_joinClass.SetActive(true);
                PhotonNetwork.LocalPlayer.NickName = playerName;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        else
        {
            Debug.Log("Player Name Empty or Invalid");
        }
    }
    #endregion
    



    #region PUN Callbacks

    public override void OnConnected()
    {
        Debug.Log("Connected to Internet");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is Connected to Photon Server!");
        ui_joinClass.SetActive(false);
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("Scene_Lobby");
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(cause);
    }

    #endregion


    
    
    #region Check If Connected to Internet

    private bool isConnectedToInternet()
    {
        string HtmlText = GetHtmlFromUri("http://google.com");
        if (HtmlText == "")
        {
            return false;
        }
        else if (!HtmlText.Contains("schema.org/WebPage"))
        {
            return true;
        }
        else
        {
            return true;
        }
    }
    private string GetHtmlFromUri(string resource)
    {
        string html = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
        try
        {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        //We are limiting the array to 80 so we don't have
                        //to parse the entire html document feel free to 
                        //adjust (probably stay under 300)
                        char[] cs = new char[80];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs)
                        {
                            html += ch;
                        }
                    }
                }
            }
        }
        catch
        {
            return "";
        }
        return html;
    }

    #endregion

}
