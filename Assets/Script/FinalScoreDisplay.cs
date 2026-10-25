using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    public TMP_Text ScoreText;           // Assign this in Inspector (Winning panel text)
    public CoinCollect coinCollector;        // Drag the Player with CoinCollect script here

    void OnEnable()
    {
        if (coinCollector != null && ScoreText != null)
        {
            ScoreText.text = coinCollector.collectedCoins.ToString();
        }
        else
        {
            Debug.LogWarning("CoinCollector or coinScoreText not assigned.");
        }
    }
}

