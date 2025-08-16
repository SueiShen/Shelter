using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSensor : MonoBehaviour, IPointerClickHandler
{
    private GameObject Talk_Canvas;
    private DailogController DailogController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Talk_Canvas = GameObject.Find("Talk_Canvas");
        if (Talk_Canvas != null) { Debug.Log("find"); } else { Debug.Log("not find"); }
        DailogController = Talk_Canvas.GetComponent<DailogController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DailogController.TurnAdd();
    }
}
