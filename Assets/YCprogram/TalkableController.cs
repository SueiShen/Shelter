using UnityEngine;

public class TalkableController : MonoBehaviour
{
    public float reachRange = 1.8f;
    public GameObject hitTarget;
    private Camera fpsCam;
    private GameObject player;

    private bool playerEntered;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private string msg;

    private int rayLayerMask;
    private ModeController ModeController;
    private DailogController DailogController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fpsCam = Camera.main;

        GameObject UI_Controller = GameObject.Find("UI_Controller");
        if (UI_Controller != null) ModeController = UI_Controller.GetComponent<ModeController>();

        GameObject Talk_Canvas = GameObject.Find("Talk_Canvas");
        if (Talk_Canvas != null) DailogController = Talk_Canvas.GetComponent<DailogController>();

        if (fpsCam == null) Debug.LogError("場景中找不到 tag 為 'MainCamera' 的攝影機。");
        if (ModeController == null || DailogController == null) Debug.LogError("找不到 ModeController 或 DailogController，請檢查場景設定！");

        LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
        rayLayerMask = 1 << iRayLM.value;
        setupGui();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) playerEntered = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerEntered = false;
            showInteractMsg = false;
        }
    }

    void Update()
    {
        if (playerEntered && ModeController != null && ModeController.mode == "Sights_mode")
        {
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, reachRange, rayLayerMask))
            {
                if (!isEqualToParent(hit.collider, out TalkableObj talkableObject) || talkableObject == null)
                {
                    showInteractMsg = false;
                    return;
                }

                showInteractMsg = true;
                msg = "按 E 講話";
                hitTarget = hit.collider.gameObject;

                if (Input.GetKeyUp(KeyCode.E) || Input.GetButtonDown("Fire1"))
                {
                    ModeController.ModeChange("Talk_mode");
                    if (DailogController != null)
                    {
                        DailogController.StartDialogue(talkableObject);
                    }
                    showInteractMsg = false;
                }
            }
            else
            {
                showInteractMsg = false;
            }
        }
    }

    private bool isEqualToParent(Collider other, out TalkableObj talkable)
    {
        talkable = null;
        bool rtnVal = false;
        try
        {
            talkable = other.GetComponentInParent<TalkableObj>();
            if (talkable != null && talkable.gameObject == this.gameObject)
            {
                rtnVal = true;
            }
        }
        catch (System.Exception e) { Debug.LogError(e.Message); }
        return rtnVal;
    }

    #region GUI Config
    private void setupGui()
    {
        guiStyle = new GUIStyle { fontSize = 36, fontStyle = FontStyle.Bold, normal = { textColor = Color.white } };
        msg = "按 E 撫摸";
    }
    void OnGUI()
    {
        if (showInteractMsg)
        {
            GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
        }
    }
    #endregion
}