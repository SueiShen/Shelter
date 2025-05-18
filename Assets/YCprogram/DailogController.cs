using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        string Content = File.ReadAllText(Locate);
        Lines = Content.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        ShowText();
    }
    public void TurnAdd()
    {

    }
    private void ShowText()
    {
        string[] Message = Lines[DailogTurn].Split(new string[] { "|" }, System.StringSplitOptions.None);
        Dailog_Text.text = Message[2];
    }
}
