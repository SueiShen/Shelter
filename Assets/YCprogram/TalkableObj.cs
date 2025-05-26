using System.IO;
using UnityEngine;

public class TalkableObj : MonoBehaviour
{
    public string TargetText =Path.Combine(Application.dataPath, "YCprogram/plot/test.txt");
    private GameObject UI_Controller;
    private ModeController ModeController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI_Controller = GameObject.Find("UI_Controller");
        ModeController = UI_Controller.GetComponent<ModeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ModeController.ModeChange("Sights_mode");
        }
    }
}
