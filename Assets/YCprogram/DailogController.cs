using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailogController : MonoBehaviour
{
    private TalkableObj currentNpc;
    public string DailogNow = "";
    public int DailogTurn = 0;
    private string[] Lines;
    private TextMeshProUGUI Dailog_Text;
    private Image Dailog_Frame;
    private TextMeshProUGUI Name_Other;
    private Image NameFrame_Other;
    private RawImage RawImage_Other;
    private TextMeshProUGUI Name_Self;
    private Image NameFrame_Self;
    private RawImage RawImage_Self;
    private GameObject UI_Controller;
    private ModeController ModeController;
    Dictionary<string, string> Name = new Dictionary<string, string>
    {
        ["NURS"] = "資深社工",
        ["DOCT"] = "獸醫師"
    };

    void Start()
    {
        Dailog_Text = GameObject.Find("Dailog_Text").GetComponent<TextMeshProUGUI>();
        Dailog_Frame = GameObject.Find("Dailog_Frame").GetComponent<Image>();
        Name_Other = GameObject.Find("Name_Other").GetComponent<TextMeshProUGUI>();
        NameFrame_Other = GameObject.Find("NameFrame_Other").GetComponent<Image>();
        RawImage_Other = GameObject.Find("RawImage_Other").GetComponent<RawImage>();
        Name_Self = GameObject.Find("Name_Self").GetComponent<TextMeshProUGUI>();
        NameFrame_Self = GameObject.Find("NameFrame_Self").GetComponent<Image>();
        RawImage_Self = GameObject.Find("RawImage_Self").GetComponent<RawImage>();
        UI_Controller = GameObject.Find("UI_Controller");
        ModeController = UI_Controller.GetComponent<ModeController>();
    }

    public void StartDialogue(TalkableObj npc)
    {
        currentNpc = npc;
        Debug.Log("DailogController 開始對話，NPC是：" + currentNpc.gameObject.name);
        string Locate = currentNpc.TargetText;
        DailogNow = Locate;
        DailogTurn = 0;
        Lines = new string[0];
        string Content = File.ReadAllText(Locate);
        Lines = Content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        Texture2D texs = Resources.Load<Texture2D>("sprites/SELF/N01");
        if (RawImage_Self != null) RawImage_Self.texture = texs;
        ShowText();
    }

    public void TurnAdd()
    {
        DailogTurn += 1;
        if (DailogTurn < Lines.Length)
        {
            ShowText();
        }
        else
        {
            EndCurrentDialogue();
        }
    }

    public void EndCurrentDialogue()
    {
        /*
        Debug.Log("--- 偵測到對話結束！正在通知 NPC... ---");
        if (currentNpc != null)
        {
            currentNpc.DialogueFinished();
            currentNpc = null;
        }
        Debug.Log("對話UI關閉，模式切換回 Sights_mode");
        ModeController.ModeChange("Sights_mode");
        */
    }

    private void ShowText()
    {
        // 增加保護，防止對話行為空
        if (Lines == null || DailogTurn >= Lines.Length || string.IsNullOrEmpty(Lines[DailogTurn])) return;

        string[] Message = Lines[DailogTurn].Split(new string[] { "|" }, StringSplitOptions.None);

        if (Message.Length < 3) return; // 保護，防止格式不符

        Dailog_Text.text = Message[2];
        switch (Message[0])
        {
            case "SELF":
                Texture2D texs = Resources.Load<Texture2D>(Path.Combine("sprites/SELF", Message[1]));
                RawImage_Self.texture = texs;
                RawImage_Self.color = Color.white;
                NameFrame_Self.color = Color.white;
                RawImage_Other.color = Color.gray;
                NameFrame_Other.color = Color.gray;
                break;
            case "CAHG":
                Debug.Log("ingame");
                ModeController.ModeChange("Catch_mode");
                break;
            default:
                Texture2D texo = Resources.Load<Texture2D>(Path.Combine("sprites", Message[0], Message[1]));
                RawImage_Other.texture = texo;
                Name_Other.text = Name[Message[0]];
                RawImage_Other.color = Color.white;
                NameFrame_Other.color = Color.white;
                RawImage_Self.color = Color.gray;
                NameFrame_Self.color = Color.gray;
                break;
        }
    }
}