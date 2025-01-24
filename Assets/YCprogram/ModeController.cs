using UnityEngine;

public class ModeController : MonoBehaviour
{
    public string mode = "Sights_mode";
    private Transform Sights_Canvas;
    private Transform FPC;
    private FirstPersonLook FirstPersonLook;
    private FirstPersonMovement FirstPersonMovement;
    private Crouch Crouch;
    private Jump Jump;
    private Transform Pet_Canvas;
    private PetableController PetableController;
    private PetableObj PetableObj;

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
        PetableController = GetComponent<PetableController>();

    }

    // Update is called once per frame
    void Update()
    {

        switch (mode)
        {
            case "Sights_mode":
                UIclose();
                Sights_Canvas.gameObject.SetActive(true);
                Moveable(true);
                Cursor.lockState = CursorLockMode.Locked;

                break;
            case "Pet_mode":
                UIclose();
                Pet_Canvas.gameObject.SetActive(true);
                Moveable(false);
                Cursor.lockState = CursorLockMode.None;

                break;
        }
    }
    void UIclose()
    {
        Pet_Canvas.gameObject.SetActive(false);
        Sights_Canvas.gameObject.SetActive(false);
    }
    void Moveable(bool move)
    {
        FirstPersonLook.Turnable = move;
        FirstPersonMovement.Moveable = move;
        Jump.Jumpable = move;
        Crouch.Crouchable = move;
    }

    public void LookTarget(Transform Target)
    {
        Debug.Log("LookTarget");
        FPC.LookAt(Target);
    }

}
