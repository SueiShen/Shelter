using System.IO;
using UnityEngine;

public class TalkableObj : MonoBehaviour
{
    // ���u�O�@�Ӽƾڮe���A���ݭn���D��L���
    [SerializeField] // �b Inspector ���áA�]������ PetableObj ����
    public string TargetText;

    [SerializeField]
    public bool isEndGameDialogue = false;

    void Awake()
    {
        // �]�w��l���
        //TargetText = Path.Combine(Application.dataPath, "YCprogram/plot/first.txt");
    }

    // �o�Ө禡�O�ߤ@��~�����f�A���� DailogController �өI�s
    public void DialogueFinished()
    {
        Debug.Log("--- TalkableObj: DialogueFinished() �Q�I�s�I isEndGameDialogue ���ȬO: " + isEndGameDialogue + " ---");

        if (isEndGameDialogue)
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        Debug.Log("--- TalkableObj: ���b�����C��... ---");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}