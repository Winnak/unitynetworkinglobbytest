# UnityNetworkingLobbyTest
The issues on disaplay are:
## Duplication on StopHost
 The Unity Networking system is creating a new instance of the LobbyManager (inherits [NetworkLobbyManager.cs](https://bitbucket.org/Unity-Technologies/networking/src/3610ab4e4c0f2a3d74bb3d005641e11201c7e6f3/Runtime/NetworkLobbyManager.cs?at=5.3&fileviewer=file-view-default#NetworkLobbyManager.cs-484))

When [LobbyManager.StopHost](./blob/master/Assets/LobbyManager.cs) is called by [OnDisconnect from the LobbySlotsPanel](./blob/master/Assets/LobbySlotsPanel.cs#L50), a new instance of the LobbyManager appears in the scene.

![Duplication issue](./blob/master/pictures/lobby-duplicate.gif)

## UI elements misplaced on Canvas
This issue appears when a new LobbyPlayer is spawned and then parented the slot. Notice how it works fine on the host, but is misplaced on the clients.

![Canvas issue](./blob/master/pictures/canvas-misplaced.png)

(A simple fix to this is to set the transform.localPosition of the LobbyPlayer to Vector3.zero on start, but that is a hack and it should be working in the first place.)
