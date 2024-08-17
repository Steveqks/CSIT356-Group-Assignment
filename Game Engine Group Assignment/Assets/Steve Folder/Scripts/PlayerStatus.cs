using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int playerLives = 10;
    public int playerMoney = 0;

    // Variable to track the value that will increment every second
    private int incrementValue = 0;

    // Variable to keep track of time
    private float timeElapsed = 0f;

    GameObject playerLivesTMP;
    TMP_Text textLives;

    GameObject playerMoneyTMP;
    TMP_Text textMoney;

    // Start is called before the first frame update
    void Start()
    {
        playerLivesTMP = GameObject.FindGameObjectWithTag("PlayerLives");
        playerMoneyTMP = GameObject.FindGameObjectWithTag("PlayerMoney");

        textLives = playerLivesTMP.GetComponent<TMP_Text>();
        textLives.text = playerLives.ToString();

        textMoney = playerMoneyTMP.GetComponent<TMP_Text>();
        textMoney.text = playerMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject obj = GameObject.FindGameObjectWithTag("PlayerLives");
        TMP_Text text = obj.GetComponent<TMP_Text>();

        // Add the time since the last frame to timeElapsed
        timeElapsed += Time.deltaTime;

        // Check if one second has passed
        if (timeElapsed >= 1f)
        {
            takeDamage(-1);
            // set new PlayerMoney value
            text.SetText(playerLives.ToString());

            // Increment the value
            //incrementValue += 1;

            // Output the value to the console (optional)
            //Debug.Log("Incremented Value: " + incrementValue);

            //playerMoney = incrementValue;
            //playerLives = incrementValue;   

            // Reset the timeElapsed, subtracting 1 to handle slight inaccuracies
            timeElapsed -= 1f;
        }
        

        
  
    }

    public void itemSold(int value)
    {
        playerMoney += value;

        // set new PlayerMoney value
        textMoney.SetText(playerMoney.ToString());
    }

    public void takeDamage(int value)
    {
        playerLives -= value;
    }
}
