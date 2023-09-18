using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    [Header("SO_Instances")]
    [SerializeField] private SOInt coins;
    [SerializeField] private SOInt superCoins;

    [Header("SO_UI_References")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI superCoinText;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetItems();
    }

    private void ResetItems()
    {
        coins.value = 0;
        superCoins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        coinText.text = "Coins: " + coins.value.ToString();

    }

    public void AddSuperCoins(int amount = 1)
    {
        superCoins.value += amount;
        superCoinText.text = "x " + superCoins.value.ToString();

    }
}
