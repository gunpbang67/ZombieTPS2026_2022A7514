using Unity.Netcode;
using UnityEngine;

// 임시 접속 버튼 - 14주차에 세션(Relay) UI로 교체 예정
public class NetworkStartUI : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 260, 120));
        NetworkManager nm = NetworkManager.Singleton;

        // 씬에 Networkmanager 가 없거나 꺼져 있으면 안내만 표시하고 끝낸다. (없으면 아래줄에서 NullReferenceException)
        if (nm == null)
        {
            GUILayout.Label("NetworkManager not found in scene");
            GUILayout.EndArea();
            return;
        }

        if (!nm.IsListening && !nm.IsServer)
        {
            // 아직 아무것도 시작하지 않은 상태
            if (GUILayout.Button("Start Host")) nm.StartHost();
            if (GUILayout.Button("Start Client")) nm.StartClient();
        }

        else
        {
            // 시작한 뒤에는 내 역할과 번호를 표시
            string mode = nm.IsHost ? "Host" : nm.IsServer ? "Server" : "Client";
            GUILayout.Label($"Mode : {mode} LocalClienId : {nm.LocalClientId}");
        }
        GUILayout.EndArea();
    }
}
