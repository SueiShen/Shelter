using UnityEngine;

public class TriggerAnimationByID : MonoBehaviour
{
    public Animator corgiAnimator; // �N Animator ���즹�B
    private bool isPlayerNear = false; // �P�_���a�O�_�a�񪫥�
    public int animationID; // �ݭn���� Animation ID

    void Update()
    {
        // �����a�b�d�򤺨ë��U E ��
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            PlayAnimationByID(animationID); // ����S�w ID ���ʵe
        }
    }

    private void PlayAnimationByID(int id)
    {
        // �ǻ� Animation ID �� Animator�A���] ID �j�w�b�ѼƤ�
        corgiAnimator.SetInteger("AnimationID", id);
        corgiAnimator.SetTrigger("PlayAnimation"); // Ĳ�o����
    }

    // �����a�i�JĲ�o�ϰ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player is near the object.");
        }
    }

    // �����a���}Ĳ�o�ϰ�
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player left the object.");
        }
    }
}