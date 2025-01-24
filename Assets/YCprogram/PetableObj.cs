using UnityEngine;
using UnityEngine.UI;

public class PetableObj : MonoBehaviour
{
    private GameObject UI_Controller;
    private ModeController ModeController;
    public int Friendship = 0;
    private Image Bar_Image;
    private RectTransform rectTransform;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI_Controller = GameObject.Find("UI_Controller");
        ModeController = UI_Controller.GetComponent<ModeController>();
        Friendship = Mathf.Clamp(Friendship, 0, 100);
        Bar_Image = GameObject.Find("Bar_Image").GetComponent<Image>();
        rectTransform = Bar_Image.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        PetableController PetableController = GetComponent<PetableController>();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ModeController.mode = "Sights_mode";
        }

        /*
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (PetableController.hitTarget == gameObject)
            {
                Friendship += 1;
                Friendship = Mathf.Clamp(Friendship, 0, 100);
            }
        }
        */
        if (PetableController.hitTarget == gameObject)
        {
            rectTransform.sizeDelta = new Vector2(Friendship * 6, 40);
            rectTransform.anchoredPosition = new Vector2(25 + (Friendship * 3), -45);
        }
    }
    public GameObject correctObj()
    {
        PetableController PetableController = GetComponent<PetableController>();
        if (PetableController.hitTarget == gameObject)
        {
            return PetableController.hitTarget;
        }
        return null;
    }


}
