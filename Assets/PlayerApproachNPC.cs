using UnityEngine;
using TMPro; // 引用 TMP 模組

public class NPCGreeting : MonoBehaviour
{
    public TextMeshProUGUI greetingText; // 用來顯示訊息的 UI TextMeshPro 元素
    public AudioClip enterSound; // 玩家進入範圍時播放的音效
    public AudioClip pressESound; // 按下 E 鍵時播放的音效
    public AudioClip exitSound; // 玩家離開範圍時播放的音效
    private AudioSource audioSource; // 音效播放器
    private bool isPlayerInRange = false; // 檢查玩家是否在範圍內

    private void Start()
    {
        // 初始化時將文字設為空，避免載入時顯示亂碼
        greetingText.text = "";

        // 取得並初始化音效播放器
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 如果玩家在範圍內，並且按下 E 鍵
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // 顯示"你好"
            greetingText.text = "Haven't Seen One of Those in a While";

            // 播放按下 E 鍵的音效
            if (pressESound != null)
            {
                audioSource.PlayOneShot(pressESound);
            }

            // 可以選擇在一段時間後隱藏訊息
            Invoke("HideMessage", 2f);  // 2秒後隱藏訊息
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 檢查是否是玩家（根據你的設定可能會是Player標籤）
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // 玩家進入範圍
            greetingText.text = "welcome Take a Look Around"; // 顯示提示訊息

            // 播放玩家進入範圍的音效
            if (enterSound != null)
            {
                audioSource.PlayOneShot(enterSound);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 當玩家離開範圍
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // 玩家離開範圍
            greetingText.text = ""; // 清除提示訊息

            // 播放玩家離開範圍的音效
            if (exitSound != null)
            {
                audioSource.PlayOneShot(exitSound);
            }
        }
    }

    // 隱藏訊息的方法
    private void HideMessage()
    {
        greetingText.text = "";
    }
}
