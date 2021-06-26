using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsTextScript : MonoBehaviour
{
    private static Text coinsText;
    void Start()
    {
        coinsText = GetComponentInChildren<Text>();
    }

    public static void UpdateUI(int coins)
    {
        coinsText.text = "Coins: " + coins.ToString();
    }
}
