using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public int LocalGold = 1000;
    public int Item1Price = 50;
    public int LocalItem1Stock = 0;
    public int Item2Price = 25;
    public int LocalItem2Stock = 0;
    public int Item3Price = 25;
    public int LocalItem3Stock = 0;
    private TextMeshProUGUI GoldHold;
    private TextMeshProUGUI Item1_Stock;
    private TextMeshProUGUI Item2_Stock;
    private TextMeshProUGUI Item3_Stock;
    private
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GoldHold = GameObject.Find("GoldHold").GetComponent<TextMeshProUGUI>();
        Item1_Stock = GameObject.Find("Item1_Stock").GetComponent<TextMeshProUGUI>();
        Item2_Stock = GameObject.Find("Item2_Stock").GetComponent<TextMeshProUGUI>();
        Item3_Stock = GameObject.Find("Item3_Stock").GetComponent<TextMeshProUGUI>();
        //if (!PlayerPrefs.HasKey("SaveGold"))
        //{
        PlayerPrefs.SetInt("SaveGold", LocalGold);
        PlayerPrefs.SetInt("SaveItem1", 0);
        PlayerPrefs.SetInt("SaveItem2", 0);
        PlayerPrefs.SetInt("SaveItem3", 0);
        PlayerPrefs.Save();
        //}
        //else
        //{
        //GetData();
        //}
        GoldHold.text = "持有現金:" + LocalGold.ToString();
        Item1_Stock.text = "已擁有:" + LocalItem1Stock.ToString();
        Item2_Stock.text = "已擁有:" + LocalItem2Stock.ToString();
        Item3_Stock.text = "已擁有:" + LocalItem3Stock.ToString();
        Debug.Log("Update");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetData()
    {
        LocalGold = PlayerPrefs.GetInt("SaveGold", 0);
        LocalItem1Stock = PlayerPrefs.GetInt("SaveItem1", 0);
        LocalItem2Stock = PlayerPrefs.GetInt("SaveItem2", 0);
        LocalItem3Stock = PlayerPrefs.GetInt("SaveItem3", 0);
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs.Get");
    }
    void SetData()
    {
        PlayerPrefs.SetInt("SaveGold", LocalGold);
        PlayerPrefs.SetInt("SaveItem1", LocalItem1Stock);
        PlayerPrefs.SetInt("SaveItem2", LocalItem2Stock);
        PlayerPrefs.SetInt("SaveItem3", LocalItem3Stock);
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs.Set");
        GoldHold.text = "持有現金:" + LocalGold.ToString();
        Item1_Stock.text = "已擁有:" + LocalItem1Stock.ToString();
        Item2_Stock.text = "已擁有:" + LocalItem2Stock.ToString();
        Item3_Stock.text = "已擁有:" + LocalItem3Stock.ToString();
        Debug.Log("Update");
    }
    public void Button1OnClicked()
    {
        //Debug.Log("Button1 clicked!");
        if (LocalGold >= Item1Price)
        {
            LocalGold -= Item1Price;
            LocalItem1Stock += 1;
            SetData();
        }
    }
    public void Button2OnClicked()
    {
        //Debug.Log("Button2 clicked!");
        if (LocalGold >= Item3Price)
        {
            LocalGold -= Item3Price;
            LocalItem2Stock += 1;
            SetData();
        }
    }
    public void Button3OnClicked()
    {
        //Debug.Log("Button3 clicked!");
        if (LocalGold >= Item3Price)
        {
            LocalGold -= Item3Price;
            LocalItem3Stock += 1;
            SetData();
        }
    }
}
