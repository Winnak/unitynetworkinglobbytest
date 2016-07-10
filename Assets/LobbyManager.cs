using UnityEngine;
using UnityEngine.Networking;

public class LobbyManager : NetworkLobbyManager
{
    [SerializeField] private LobbySlotsPanel m_LobbySlotsPanel;
    [SerializeField] private LobbyConnectionPanel m_LobbyConnectionPanel;

    private void Awake()
    {
        Debug.Assert(m_LobbySlotsPanel != null, "Lobby manager is missing a reference to its slots panel", this);
        Debug.Assert(m_LobbyConnectionPanel != null, "Lobby manager is missing a reference to its connection panel", this);
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        SwitchToLobby();
    }

    public override GameObject OnLobbyServerCreateLobbyPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject obj = Instantiate(lobbyPlayerPrefab.gameObject) as GameObject;
        //LobbyPlayer lobbyPlayerScript = lobbyPlayerPrefab.GetComponent<LobbyPlayer>();
        return obj;
    }

    public void SwitchToLobby()
    {
        m_LobbyConnectionPanel.gameObject.SetActive(false);
        m_LobbySlotsPanel.gameObject.SetActive(true);
    }

    public void SwitchToConnection()
    {
        m_LobbyConnectionPanel.gameObject.SetActive(true);
        m_LobbySlotsPanel.gameObject.SetActive(false);
    }
}