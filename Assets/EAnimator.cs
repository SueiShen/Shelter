using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public GameObject targetObject; // 目標物件
    public float interactionDistance = 3f; // 互動範圍
    private Animator targetAnimator; // 目標物件的 Animator

    void Start()
    {
        // 確保目標物件有 Animator 組件
        if (targetObject != null)
        {
            targetAnimator = targetObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        // 檢查玩家與目標物件的距離
        float distance = Vector3.Distance(transform.position, targetObject.transform.position);

        // 當玩家靠近並按下 E 鍵時觸發動畫
        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            if (targetAnimator != null)
            {
                targetAnimator.SetTrigger("PlayAnimation"); // 播放動畫，這裡的 "PlayAnimation" 是動畫的觸發器
            }
        }
    }
}
