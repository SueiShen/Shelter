using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleporter : MonoBehaviour
{
    public GameObject targetObject; // ��J�ؼЪ���
    public string targetSceneName; // �ؼг����W��

    private void OnTriggerEnter(Collider other)
    {
        // �ˬd�O�_�����a
        if (other.CompareTag("Player"))
        {
            // �p�G�]�m�F�ؼг����W�١A�h��������
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                SceneManager.LoadScene(targetSceneName);
                SceneManager.sceneLoaded += OnSceneLoaded; // �q�\�������J�ƥ�
            }
            else
            {
                // �p�G�ؼг����W�٬��šA�h�����ǰe��ؼЪ����m
                TeleportPlayer(other.gameObject);
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �T�O���J���O�ؼг���
        if (scene.name == targetSceneName)
        {
            GameObject player = GameObject.FindWithTag("Player"); // ��쪱�a
            if (player != null && targetObject != null)
            {
                player.transform.position = targetObject.transform.position; // �ǰe��ؼЪ����m
            }
        }
        SceneManager.sceneLoaded -= OnSceneLoaded; // �����ƥ�q�\
    }

    private void TeleportPlayer(GameObject player)
    {
        // �ǰe���a��ؼЪ����m
        if (targetObject != null)
        {
            player.transform.position = targetObject.transform.position;
        }
    }
}