using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LobbyPlayer : NetworkLobbyPlayer
{
    [Header("What other players see")]
    [SerializeField] private GameObject m_OtherObject;
    [SerializeField] private Text m_OtherTeam;
    [SerializeField] private Text m_OtherRole;
    [SerializeField] private Text m_OtherReady;

    [Header("Local for the player")]
    [SerializeField] private GameObject m_LocalObject;
    [SerializeField] private Text m_LocalYouText;
    [SerializeField] private Button m_LocalTeamButton;
    [SerializeField] private Button m_LocalRoleButton;
    [SerializeField] private Button m_LocalReadyButton;
    
    public override void OnClientEnterLobby()
    {
        base.OnClientEnterLobby();
        LobbySlotsPanel.Instance.FillLobbySlot(this);
    }
    
    private void Start()
    {
        if (isLocalPlayer)
        {
            m_LocalObject.SetActive(true);
            m_OtherObject.SetActive(false);
        }
        else
        {
            m_LocalObject.SetActive(false);
            m_OtherObject.SetActive(true);
        }
    }
}