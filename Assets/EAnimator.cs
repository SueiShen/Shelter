using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public GameObject targetObject; // �ؼЪ���
    public float interactionDistance = 3f; // ���ʽd��
    private Animator targetAnimator; // �ؼЪ��� Animator

    void Start()
    {
        // �T�O�ؼЪ��� Animator �ե�
        if (targetObject != null)
        {
            targetAnimator = targetObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        // �ˬd���a�P�ؼЪ��󪺶Z��
        float distance = Vector3.Distance(transform.position, targetObject.transform.position);

        // �����a�a��ë��U E ���Ĳ�o�ʵe
        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            if (targetAnimator != null)
            {
                targetAnimator.SetTrigger("PlayAnimation"); // ����ʵe�A�o�̪� "PlayAnimation" �O�ʵe��Ĳ�o��
            }
        }
    }
}