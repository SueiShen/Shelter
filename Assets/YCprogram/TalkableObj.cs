using System.IO;
using UnityEngine;

public class TalkableObj : MonoBehaviour
{
    // 它只是一個數據容器，不需要知道其他控制器
    [HideInInspector] // 在 Inspector 隱藏，因為它由 PetableObj 控制
    public string TargetText;

    [HideInInspector]
    public bool isEndGameDialogue = false;

    void Awake()
    {
        // 設定初始對話
        TargetText = Path.Combine(Application.dataPath, "YCprogram/plot/test.txt");
    }

    // 這個函式是唯一對外的接口，等待 DailogController 來呼叫
    public void DialogueFinished()
    {
        Debug.Log("--- TalkableObj: DialogueFinished() 被呼叫！ isEndGameDialogue 的值是: " + isEndGameDialogue + " ---");

        if (isEndGameDialogue)
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        Debug.Log("--- TalkableObj: 正在結束遊戲... ---");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}