using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleporter : MonoBehaviour
{
    public GameObject targetObject; // 拖入目標物件
    public string targetSceneName; // 目標場景名稱

    private void OnTriggerEnter(Collider other)
    {
        // 檢查是否為玩家
        if (other.CompareTag("Player"))
        {
            // 如果設置了目標場景名稱，則切換場景
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                SceneManager.LoadScene(targetSceneName);
                SceneManager.sceneLoaded += OnSceneLoaded; // 訂閱場景載入事件
            }
            else
            {
                // 如果目標場景名稱為空，則直接傳送到目標物件位置
                TeleportPlayer(other.gameObject);
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 確保載入的是目標場景
        if (scene.name == targetSceneName)
        {
            GameObject player = GameObject.FindWithTag("Player"); // 找到玩家
            if (player != null && targetObject != null)
            {
                player.transform.position = targetObject.transform.position; // 傳送到目標物件位置
            }
        }
        SceneManager.sceneLoaded -= OnSceneLoaded; // 取消事件訂閱
    }

    private void TeleportPlayer(GameObject player)
    {
        // 傳送玩家到目標物件位置
        if (targetObject != null)
        {
            player.transform.position = targetObject.transform.position;
        }
    }
}
