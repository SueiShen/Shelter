using UnityEngine;
using TMPro;
using System.Collections;

public class MinigamesController : MonoBehaviour
{
    private GameObject UI_Controller;
    private ModeController ModeController;
    [Header("UI 元件")]             // 在 Inspector 加一個可讀分隔標題
    [SerializeField]                 // 私有欄位但仍可在 Inspector 指派
    private TextMeshPro scoreText; // UI 文字元件（Canvas 上的 TMP 文本），用來顯示倒數
    [SerializeField] private GameObject tutorialPanel;

    [Header("掉落物設定")]           // 另一個 Inspector 分隔標題
    public GameObject[] dropsPrefabs;   // 要生成的 Drops 預製物（Prefab）
    [Range(0, 100)]
    public int[] dropWeights;

    // 可選生成點清單（五個座標）
    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(-4, 4, 1),       // 座標 1
        new Vector3(-2, 4, 1),       // 座標 2
        new Vector3(0, 4, 1),        // 座標 3
        new Vector3(2, 4, 1),        // 座標 4
        new Vector3(4, 4, 1)         // 座標 5
    };

    public int TotalScore = 0;
    [SerializeField] private int countdownTime = 60;
    private int timeLeft;
    private bool gameStarted = false;

    private void Start()
    {
        UI_Controller = GameObject.Find("UI_Controller");
        ModeController = UI_Controller.GetComponent<ModeController>();
        timeLeft = countdownTime;
        //Time.timeScale = 0f;         // 遊戲暫停
        tutorialPanel.SetActive(true); // 顯示玩法說明
    }
    void Update()
    {
            
            if (!gameStarted && Input.anyKeyDown && ModeController.mode=="Catch_mode") // 按任意鍵開始
            {
                StartGame();
            }
            

    }
    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f;            // 恢復時間
        tutorialPanel.SetActive(false); // 關閉玩法說明 UI

        StartCoroutine(CountdownTimer());
        StartCoroutine(SpawnDropsRoutine());
    }
    private IEnumerator CountdownTimer()
    {
        while (timeLeft > 0)
        {
            scoreText.text = "時間: " + timeLeft;
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        scoreText.text = "時間到!";
        //ModeController.ModeChange("Pet_mode");
    }
    private IEnumerator SpawnDropsRoutine() // 第二條協程：控制生成掉落物
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(2f);

            // 隨機選一個位置
            int posIndex = Random.Range(0, spawnPositions.Length);

            // 根據權重選一個 Prefab
            int prefabIndex = GetRandomDropIndex();

            // 生成掉落物
            Instantiate(dropsPrefabs[prefabIndex], spawnPositions[posIndex], Quaternion.identity);
        }
    }
    private int GetRandomDropIndex()
    {
        int totalWeight = 0;
        foreach (int w in dropWeights)
        {
            totalWeight += w;
        }

        int randomValue = Random.Range(0, totalWeight);
        int cumulative = 0;

        for (int i = 0; i < dropWeights.Length; i++)
        {
            cumulative += dropWeights[i];
            if (randomValue < cumulative)
            {
                return i; // 回傳該 Prefab 的索引
            }
        }
        return 0; // 保險：理論上不會跑到這
    }
}
