using UnityEngine;
using UnityEngine.UI;

public class LobbyConnectionPanel : MonoBehaviour
{
    [SerializeField] private LobbyManager m_LobbyManager;
    [SerializeField] private Button m_ConnectButton;
    [SerializeField] private Button m_HostButton;
    [SerializeField] private InputField m_IPField;

    private void Awake()
    {
        Debug.Assert(m_ConnectButton != null, "Lobby connection menu is missing a reference to its connection button.", this);
        Debug.Assert(m_HostButton != null, "Lobby connection menu is missing a reference to its host button.", this);
        Debug.Assert(m_IPField != null, "Lobby connection menu is missing a reference to its ip field.", this);
        Debug.Assert(m_LobbyManager != null, "Lobby connection menu is missing a reference to the lobby manager.", this);

        m_IPField.text = "127.0.0.1";
    }

    public void OnConnectButton()
    {
        m_LobbyManager.networkAddress = m_IPField.text;
        m_LobbyManager.StartClient();
        m_LobbyManager.SwitchToLobby();
    }

    public void OnHostButton()
    {
        m_LobbyManager.StartHost();
    }
}
