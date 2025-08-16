using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class DailogController : MonoBehaviour
{
    public string DailogNow = "";
    public int DailogTurn = 0;
    private string[] Lines;
    private string TextNow = "";
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        //ShowText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetDailog(string Locate)
    {
        DailogNow = Locate;
        DailogTurn = 0;
        Lines = new string[0];
        string Content = System.IO.File.ReadAllText(Locate);
        Lines = Content.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        Texture2D texs = Resources.Load<Texture2D>("sprites/SELF/N01");
        RawImage_Self.texture = texs;
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
            Debug.Log("textout");
            ModeController.ModeChange("Sights_mode");
        }

    }
    private void ShowText()
    {
        string[] Message = Lines[DailogTurn].Split(new string[] { "|" }, System.StringSplitOptions.None);

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
