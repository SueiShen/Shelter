using UnityEngine;

public class TriggerAnimationByID : MonoBehaviour
{
    public Animator corgiAnimator; // 將 Animator 拖放到此處
    private bool isPlayerNear = false; // 判斷玩家是否靠近物件
    public int animationID; // 需要播放的 Animation ID

    void Update()
    {
        // 當玩家在範圍內並按下 E 鍵
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            PlayAnimationByID(animationID); // 播放特定 ID 的動畫
        }
    }

    private void PlayAnimationByID(int id)
    {
        // 傳遞 Animation ID 給 Animator，假設 ID 綁定在參數中
        corgiAnimator.SetInteger("AnimationID", id);
        corgiAnimator.SetTrigger("PlayAnimation"); // 觸發播放
    }

    // 當玩家進入觸發區域
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player is near the object.");
        }
    }

    // 當玩家離開觸發區域
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player left the object.");
        }
    }
}
