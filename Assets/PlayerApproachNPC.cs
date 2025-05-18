using UnityEngine;
using TMPro; // �ޥ� TMP �Ҳ�

public class NPCGreeting : MonoBehaviour
{
    public TextMeshProUGUI greetingText; // �Ψ���ܰT���� UI TextMeshPro ����
    public AudioClip enterSound; // ���a�i�J�d��ɼ��񪺭���
    public AudioClip pressESound; // ���U E ��ɼ��񪺭���
    public AudioClip exitSound; // ���a���}�d��ɼ��񪺭���
    private AudioSource audioSource; // ���ļ���
    private bool isPlayerInRange = false; // �ˬd���a�O�_�b�d��

    private void Start()
    {
        // ��l�ƮɱN��r�]���šA�קK���J����ܶýX
        greetingText.text = "";

        // ���o�ê�l�ƭ��ļ���
        audioSource = GetComponent<AudioSource>();
    }
/*
    private void Update()
    {
        // �p�G���a�b�d�򤺡A�åB���U E ��
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // ���"�A�n"
            greetingText.text = "Haven't Seen One of Those in a While";

            // ������U E �䪺����
            if (pressESound != null)
            {
                audioSource.PlayOneShot(pressESound);
            }

            // �i�H��ܦb�@�q�ɶ������ðT��
            Invoke("HideMessage", 2f);  // 2�������ðT��
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �ˬd�O�_�O���a�]�ھڧA���]�w�i��|�OPlayer���ҡ^
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // ���a�i�J�d��
            greetingText.text = "welcome Take a Look Around"; // ��ܴ��ܰT��

            // ���񪱮a�i�J�d�򪺭���
            if (enterSound != null)
            {
                audioSource.PlayOneShot(enterSound);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �����a���}�d��
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // ���a���}�d��
            greetingText.text = ""; // �M�����ܰT��

            // ���񪱮a���}�d�򪺭���
            if (exitSound != null)
            {
                audioSource.PlayOneShot(exitSound);
            }
        }
    }

    // ���ðT������k
    private void HideMessage()
    {
        greetingText.text = "";
    }
    */
}
