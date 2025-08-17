using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PetableObj : MonoBehaviour
{
    private GameObject UI_Controller;
    private ModeController ModeController;
    public int Friendship = 0;
    public float sensitivity = 10f;

    // 在 Unity 編輯器中，將擁有 TalkableObj 腳本的 NPC 物件拖曳到這裡
    public TalkableObj targetTalkableObj;
    private bool isMaxFriendshipTriggered = false; // 確保觸發事件只執行一次

    private Image Bar_Image;
    private RectTransform PetCursor;
    private RectTransform rectTransform;
    private PetableController PetableController;

    void Start()
    {
        UI_Controller = GameObject.Find("UI_Controller");
        ModeController = UI_Controller.GetComponent<ModeController>();
        Friendship = Mathf.Clamp(Friendship, 0, 100);
        Bar_Image = GameObject.Find("Bar_Image").GetComponent<Image>();
        PetCursor = GameObject.Find("PetCursor").GetComponent<RectTransform>();
        rectTransform = Bar_Image.GetComponent<RectTransform>();
        PetableController = GetComponent<PetableController>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ModeController.ModeChange("Sights_mode");
        }
        if (PetableController.hitTarget == gameObject)
        {
            rectTransform.sizeDelta = new Vector2(Friendship * 6, 40);
            rectTransform.anchoredPosition = new Vector2(25 + (Friendship * 3), -45);
            PetCursor.position = Input.mousePosition;
        }
    }

    private Vector3 lastMousePosition;
    private float accumulatedDistance = 0f;
    private float updateInterval = 0.1f;
    private float lastUpdateTime = 0f;

    void OnMouseOver()
    {
        if (ModeController.mode == "Pet_mode")
        {
            Vector3 currentMousePosition = Input.mousePosition;
            accumulatedDistance += Vector3.Distance(currentMousePosition, lastMousePosition);

            if (Time.time - lastUpdateTime >= updateInterval && accumulatedDistance > sensitivity)
            {
                if (Friendship < 100)
                {
                    Friendship += 1;
                    Friendship = Mathf.Clamp(Friendship, 0, 100);
                }
                accumulatedDistance = 0f;
                lastUpdateTime = Time.time;
            }

            lastMousePosition = currentMousePosition;

            // ----- 修改部分開始 -----
            // 檢查好感度是否達到100，並且尚未觸發過
            if (Friendship >= 100 && !isMaxFriendshipTriggered)
            {
                isMaxFriendshipTriggered = true; // 標記為已觸發，防止重複執行

                Debug.Log("好感度已滿！請回去找 NPC 對話。");

                // 檢查 targetTalkableObj 是否已經設定
                if (targetTalkableObj != null)
                {
                    // 1. 更改 TalkableObj 的 TargetText
                    targetTalkableObj.TargetText = Path.Combine(Application.dataPath, "YCprogram/plot/end.txt");

                    // 2. 設定 TalkableObj 的結束遊戲旗標
                    targetTalkableObj.isEndGameDialogue = true;

                    Debug.Log("目標文本已更換為: " + targetTalkableObj.TargetText + "，並設定結束旗標。");
                }
                else
                {
                    Debug.LogError("尚未在 PetableObj 的 Inspector 中指定 targetTalkableObj！");
                }
            }
            // ----- 修改部分結束 -----
        }
    }
}