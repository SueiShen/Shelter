using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    [Header("移動參數")]
    public float moveSpeed = 5f; // 移動速度

    [Header("邊界限制")]
    public float minX = -5f; // 最左邊界
    public float maxX = 5f;  // 最右邊界

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        // 取得輸入 (A = -1, D = 1, 沒按 = 0)
        float moveInput = Input.GetAxisRaw("Horizontal");

        // 計算移動向量
        Vector3 movement = new Vector3(moveInput * moveSpeed * Time.deltaTime, 0f, 0f);

        // 移動物件
        transform.position += movement;

        // 限制物件在 X 軸上的位置
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
