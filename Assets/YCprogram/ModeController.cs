using UnityEngine;

public class ModeController : MonoBehaviour
{
    public string mode = "Sights_mode";
    public Texture2D PetCursor;
    private Transform Sights_Canvas;
    private Transform FPC;
    private FirstPersonLook FirstPersonLook;
    private FirstPersonMovement FirstPersonMovement;
    private Crouch Crouch;
    private Jump Jump;
    private Transform Pet_Canvas;
    private Transform Shop_Canvas;

    private Transform Talk_Canvas;
    private ShopController ShopController;
    private PetableController PetableController;
    private PetableObj PetableObj;
    private Transform FirstPersonController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sights_Canvas = transform.Find("Sights_Canvas");
        FPC = transform.parent.Find("First Person Camera");
        FirstPersonLook = FPC.GetComponent<FirstPersonLook>();
        Transform controller = FPC.parent;
        FirstPersonMovement = controller.GetComponent<FirstPersonMovement>();
        Jump = controller.GetComponent<Jump>();
        Crouch = controller.GetComponent<Crouch>();
        Pet_Canvas = transform.Find("Pet_Canvas");
        Shop_Canvas = transform.Find("Shop_Canvas");
        ShopController = Shop_Canvas.GetComponent<ShopController>();
        Talk_Canvas = transform.Find("Talk_Canvas");
        PetableController = GetComponent<PetableController>();
        FirstPersonController = gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            mode = "Talk_mode";
            ShopController.GetData();
        }
        switch (mode)
        {
            case "Sights_mode":
                UIclose();
                Sights_Canvas.gameObject.SetActive(true);
                Moveable(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
                //Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
                break;
            case "Pet_mode":
                UIclose();
                Pet_Canvas.gameObject.SetActive(true);
                Moveable(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                //Cursor.SetCursor(PetCursor,new Vector2(0,0),CursorMode.Auto);
                break;
            case "Shop_mode":
                UIclose();
                Shop_Canvas.gameObject.SetActive(true);
                Moveable(false);
                Cursor.lockState = CursorLockMode.None;
                //ShopController.UpdateData();
                break;
            case "Talk_mode":
                UIclose();
                Talk_Canvas.gameObject.SetActive(true);
                Moveable(false);
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
    void UIclose()
    {
        Sights_Canvas.gameObject.SetActive(false);
        Pet_Canvas.gameObject.SetActive(false);
        Shop_Canvas.gameObject.SetActive(false);
        Talk_Canvas.gameObject.SetActive(false);
        
    }
    void Moveable(bool move)
    {
        FirstPersonLook.Turnable = move;
        FirstPersonMovement.Moveable = move;
        Jump.Jumpable = move;
        Crouch.Crouchable = move;
    }
    private Quaternion savedRotation;
    public void LookTarget(Transform Target)
    {
        //Debug.Log("LookTarget");
        FPC.LookAt(Target);

        FirstPersonController.position = Target.position + Target.forward * 1f;
    }

}
