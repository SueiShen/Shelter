using UnityEngine;
using UnityEngine.UI;

public class PetableObj : MonoBehaviour
{
    private GameObject UI_Controller;
    private ModeController ModeController;
    public int Friendship = 0;
    public float sensitivity = 10f;

    private Image Bar_Image;
    private RectTransform PetCursor;
    private RectTransform rectTransform;

    private PetableController PetableController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
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
    private float updateInterval = 0.1f; // 更新間隔
    private float lastUpdateTime = 0f; // 上次更新時間
    void OnMouseOver()
    {
        if (ModeController.mode == "Pet_mode")
        {
        // 獲取當前鼠標位置
        Vector3 currentMousePosition = Input.mousePosition;

        // 計算鼠標移動距離並累積
        accumulatedDistance += Vector3.Distance(currentMousePosition, lastMousePosition);

        // 判斷時間間隔和累積距離是否達標
        if (Time.time - lastUpdateTime >= updateInterval && accumulatedDistance > sensitivity)
        {
            // 增加好感度
            Friendship += 1;
            Friendship = Mathf.Clamp(Friendship, 0, 100); // 限制好感度範圍

            // 重置累積距離和時間
            accumulatedDistance = 0f;
            lastUpdateTime = Time.time;
        }

        // 更新鼠標上次位置
        lastMousePosition = currentMousePosition;
        }
    }
}
