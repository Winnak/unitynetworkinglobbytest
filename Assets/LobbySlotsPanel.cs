using UnityEngine;
using UnityEngine.UI;

public class LobbySlotsPanel : MonoBehaviour
{
    [SerializeField] private LobbyManager m_LobbyManager;
    [SerializeField] private Text m_SlotStatusText;
    [SerializeField] private Image[] m_PlayerSlotImages;
    [SerializeField] private Button m_DisconnectButton;

    public static LobbySlotsPanel Instance; // TODO: not really necesary.

    private LobbyPlayer[] m_LobbyPlayers;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            Debug.LogError("Another instance of this was already found", this);
            return;
        }
        Instance = this;

        Debug.Assert(m_LobbyManager != null, "Player slots managers refernce to the lobby manager is missing", this);
        Debug.Assert(m_PlayerSlotImages != null, "Player slots manager is missing references to its slot images", this);
        Debug.Assert(m_PlayerSlotImages.Length == 4, "Player slots manager does not have 4 references to slot images", this);

        m_LobbyPlayers = new LobbyPlayer[m_PlayerSlotImages.Length];

        Debug.Assert(m_SlotStatusText != null, "Player slots managers status text is missing", this);
        Debug.Assert(m_DisconnectButton != null, "Player slots managers disconnect button is missing", this);
    }
    
    public void FillLobbySlot(LobbyPlayer player)
    {
        for (int i = 0; i < m_LobbyPlayers.Length; i++)
        {
            if (m_LobbyPlayers[i] == null)
            {
                m_LobbyPlayers[i] = player;
                player.transform.SetParent(m_PlayerSlotImages[i].transform, false);
                return;
            }
        }

        Debug.LogError("Could not find a spot for the player");
    }

    public void OnDisconnect()
    {
        m_LobbyManager.StopHost();
        m_LobbyManager.StopClient();
        m_LobbyManager.SwitchToConnection();

    }
}