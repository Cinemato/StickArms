using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] string VersionName = "0.1";
    [SerializeField] GameObject UsernameMenu;
    [SerializeField] GameObject ConnectPanel;

    [SerializeField] InputField UsernameInput;
    [SerializeField] InputField CreateGameInput;
    [SerializeField] InputField JoinGameInput;

    [SerializeField] GameObject StartButton;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void Start()
    {
        UsernameMenu.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("CONNECTED!");
    }

    public void validateUserName()
    {
        if(UsernameInput.text.Length >= 4)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void setPlayerName()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }
}
