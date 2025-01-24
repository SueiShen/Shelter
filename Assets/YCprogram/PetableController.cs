using UnityEngine;

public class PetableController : MonoBehaviour
{
    public float reachRange = 1.8f;
    public GameObject hitTarget ;
    private GameObject FPC;
    private Camera fpsCam;
    private GameObject player;

    private bool playerEntered;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private string msg;

    private int rayLayerMask;
    private GameObject UI_Controller;
    private ModeController ModeController;

    void Start()
    {
        // Initialize references
        player = GameObject.FindGameObjectWithTag("Player");
        fpsCam = Camera.main;
        UI_Controller = GameObject.Find("UI_Controller");
        ModeController = UI_Controller.GetComponent<ModeController>();
        FPC = GameObject.Find("First Person Camera");
        if (fpsCam == null)
        {
            Debug.LogError("A camera tagged 'MainCamera' is missing.");
        }

        // Configure the raycast layer mask
        LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
        rayLayerMask = 1 << iRayLM.value;

        // Setup GUI style for prompts
        setupGui();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerEntered = true;
            //Debug.Log("Player entered interaction zone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerEntered = false;
            showInteractMsg = false;
            //Debug.Log("Player exited interaction zone.");
        }
    }

    void Update()
    {
        if (playerEntered && (ModeController.mode == "Sights_mode"))
        {
            //Debug.Log("Player is in interaction zone.");
            // Center point of viewport in World space
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            // Perform raycast
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, reachRange, rayLayerMask))
            {
                //Debug.Log($"Raycast hit object: {hit.collider.gameObject.name}");
                PetableObj petableObject = null;

                // Check if the hit object or its parent has PetableObj
                if (!isEqualToParent(hit.collider, out petableObject))
                {
                    //Debug.Log("Raycast hit an object, but it's not interactable.");
                    return;
                }

                if (petableObject != null)
                {
                    showInteractMsg = true;
                    msg = "按 E 互動";
                    hitTarget = hit.collider.gameObject;

                    if (Input.GetKeyUp(KeyCode.E) || Input.GetButtonDown("Fire1"))
                    {
                        //Debug.Log("E key or Fire1 button pressed.");
                        ModeController.mode = "Pet_mode";
                        showInteractMsg = false;
                        ModeController.LookTarget(gameObject.transform);
                    }
                }
            }
            else
            {
                showInteractMsg = false;
                //Debug.Log("Raycast did not hit any object.");
            }
        }
    }

    private bool isEqualToParent(Collider other, out PetableObj petable)
    {
        petable = null;
        bool rtnVal = false;

        try
        {
            int maxWalk = 6;
            petable = other.GetComponent<PetableObj>();

            GameObject currentGO = other.gameObject;
            for (int i = 0; i < maxWalk; i++)
            {
                if (currentGO.Equals(this.gameObject))
                {
                    rtnVal = true;
                    if (petable == null) petable = currentGO.GetComponentInParent<PetableObj>();
                    break;
                }

                if (currentGO.transform.parent != null)
                {
                    currentGO = currentGO.transform.parent.gameObject;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }

        return rtnVal;
    }

    #region GUI Config

    private void setupGui()
    {
        guiStyle = new GUIStyle
        {
            fontSize = 36,
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.white }
        };
        msg = "按 E 撫摸";
    }

    void OnGUI()
    {
        if (showInteractMsg)
        {
            GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
        }
    }
    public GameObject GetHitTarget()
    {
        return hitTarget; // 提供公共方法獲取 hitTarget
    }
    #endregion
}
