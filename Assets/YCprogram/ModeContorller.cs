using UnityEngine;

public class ModeContorller : MonoBehaviour
{
    public string mode = "Sights_mode";
    private Transform Sights_Canvas;
    private Transform FPC;
    private FirstPersonLook FirstPersonLook;
    private Transform Pet_Canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sights_Canvas = transform.Find("Sights_Canvas");
        FPC = transform.parent.Find("First Person Camera");
        FirstPersonLook = FPC.GetComponent<FirstPersonLook>();
        Pet_Canvas = transform.Find("Pet_Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case "Sights_mode":
                close();
                Sights_Canvas.gameObject.SetActive(true);
                FirstPersonLook.moveable = true;
                Cursor.lockState = CursorLockMode.Locked;

                break;
            case "Pet_mode":
                close();
                Pet_Canvas.gameObject.SetActive(true);
                FirstPersonLook.moveable = false;
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
    void close()
    {
        Pet_Canvas.gameObject.SetActive(false);
        Sights_Canvas.gameObject.SetActive(false);
    }
}
