using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public int collectedCoins=0;
    public TMP_Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        //collectedCoins = PlayerPrefs.GetInt("Coin");        // Load the previously saved number of collected coins from local storage.
                                                             // If no value was saved before, it defaults to 0.
        coinText.text = collectedCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag=="Coin")
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
            collectedCoins= collectedCoins+10 ;

            //PlayerPrefs.SetInt("Coin", collectedCoins);           // Save the updated number of collected coins to local storage
                                                                   // so it can be loaded again in the next session.
            coinText.text=collectedCoins.ToString();
        }
    }
}
