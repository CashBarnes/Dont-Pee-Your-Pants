using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public WaterGauge theWaterLevel;
    public PeeGauge thePeeLevel;
    public float addedPee;
    public AudioSource gulpSound;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            theWaterLevel.waterCount = 1f;
            thePeeLevel.peeCount += addedPee;
            gulpSound.Play();
        }
        gameObject.SetActive(false);
    }
}
