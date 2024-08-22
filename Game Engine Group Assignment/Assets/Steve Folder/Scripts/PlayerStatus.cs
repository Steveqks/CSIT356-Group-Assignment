using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int playerLives = 0;
    [SerializeField] private int playerMoney = 0;

    // Variable to track the value that will increment every second
    private int incrementValue = 0;

    // Variable to keep track of time
    private float timeElapsed = 0f;
    
    // used for updating lives being displayed on player UI
    private GameObject playerLivesTMP;
    private TMP_Text textLives;

    // used for updating money being displayed on player UI
    private GameObject playerMoneyTMP;
    private TMP_Text textMoney;

    // Start is called before the first frame update
    void Start()
    {
        // retreive TMP text
        playerLivesTMP = GameObject.FindGameObjectWithTag("PlayerLives");
        playerMoneyTMP = GameObject.FindGameObjectWithTag("PlayerMoney");

        // set TMP text to starting player status from PlayerStatus settings
        textLives = playerLivesTMP.GetComponent<TMP_Text>();
        textLives.text = playerLives.ToString();
        textMoney = playerMoneyTMP.GetComponent<TMP_Text>();
        textMoney.text = playerMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        //GameObject obj = GameObject.FindGameObjectWithTag("PlayerLives");
        //TMP_Text text = obj.GetComponent<TMP_Text>();

        // Add the time since the last frame to timeElapsed
        timeElapsed += Time.deltaTime;

        // Check if one second has passed
        if (timeElapsed >= 1f)
        {
            // for testing player live
            //takeDamage(-1);


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
    public int getPlayerLives()
    {
        return playerLives;
    }

    public int getPlayerMoney()
    {
        return playerMoney;
    }
    public void takeDamage(int value)
    {
        playerLives -= value;
        textLives.text = playerLives.ToString();
    }
    public void enemyReward(int value)
    {
        playerMoney += value;
        textMoney.text = playerMoney.ToString();
    }

    public void towerBought(int value)
    {
        playerMoney -= value;

        // set new PlayerMoney value
        textMoney.SetText(playerMoney.ToString());
    }

    public void towerSold(int value)
    {
        playerMoney += value;

        // set new PlayerMoney value
        textMoney.SetText(playerMoney.ToString());
    }

}
