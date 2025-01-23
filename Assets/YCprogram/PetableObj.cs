using UnityEngine;
using UnityEngine.UI;

public class PetableObj : MonoBehaviour
{
    private GameObject UI_Contorller;
    private ModeContorller ModeContorller;
    public int Friendship = 0;
    private Image Bar_Image;
    private RectTransform rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI_Contorller = GameObject.Find("UI_Contorller");
        ModeContorller = UI_Contorller.GetComponent<ModeContorller>();
        Friendship = Mathf.Clamp(Friendship, 0, 100);
        Bar_Image = GameObject.Find("Bar_Image").GetComponent<Image>();
        rectTransform = Bar_Image.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ModeContorller.mode = "Sights_mode";
        }
        rectTransform.sizeDelta = new Vector2(Friendship*6, 40);
    }

    
}
