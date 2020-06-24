using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGauge : MonoBehaviour
{
    private Transform bar;
    public float waterCount;
    public float waterPerSecond;
    public Text thirstText;
    public GameObject pauseButton;

    public ScoreManager theScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        Transform bar = transform.Find("Bar");   
        
    }

    public void ResetWater()
    {
        waterCount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(waterCount > 0 && theScoreManager.scoreIncreasing)
        {
            Transform bar = transform.Find("Bar"); 
            waterCount -= waterPerSecond * Time.deltaTime;
            bar.localScale = new Vector3( waterCount , 1f);
        }

        else if (waterCount <= 0)
        {
            
            thirstText.text = "You died of thirst!";
            pauseButton.SetActive(false);
            FindObjectOfType<GameManager>().RestartGame();
                       
        }
        
    }
    
}
