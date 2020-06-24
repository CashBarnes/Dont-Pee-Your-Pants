using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeeGauge : MonoBehaviour
{
    private Transform bar;
    public float peeCount;
    public Text peedText;
    public GameObject pauseButton;
    
    //public ScoreManager theScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        Transform bar = transform.Find("Bar");   
        
    }

    public void ResetPee()
    {
        peeCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Transform bar = transform.Find("Bar"); 
        bar.localScale = new Vector3( peeCount , 1f);
        if (peeCount >= 1)
        {
            peedText.text = "You peed your pants!";
            FindObjectOfType<GameManager>().RestartGame();
            pauseButton.SetActive(false);            
        }
        
    }
    
}
