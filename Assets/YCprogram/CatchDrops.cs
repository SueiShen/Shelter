using TMPro;
using UnityEngine;

public class CatchDrops : MonoBehaviour
{
    public int points = 5;
    public SpriteRenderer spriteRenderer;
    private TextMeshPro Score;
    private GameObject MiniGames_root;
    private MinigamesController MinigamesController;
    //private Transform Drops;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = GameObject.Find("Score").GetComponent<TextMeshPro>();
        MiniGames_root = GameObject.Find("MiniGames_root");
        MinigamesController = MiniGames_root.GetComponent<MinigamesController>();
        //Drops = transform.Find("Drops");
    }
    public void SetAsObstacle(int penalty, Sprite obstacleSprite)
    {
        points = penalty;              // 設定成扣分
        spriteRenderer.sprite = obstacleSprite; // 換貼圖
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(Drops, new Vector3(0, 4, 1), Quaternion.identity);
        }
        */
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player2D")
        {
            Debug.Log("hit player");
            MinigamesController.TotalScore += points;
            Score.text = "分數:" + MinigamesController.TotalScore.ToString();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Destroy")
        {
            Debug.Log("hit bottom");
            Destroy(this.gameObject);
        }
    }
}
