using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    public PeeGauge thePeeLevel;
    public AudioSource flushSound;
    //public Text peedText;
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
            thePeeLevel.peeCount = 0f;
            flushSound.Play();
            
        }
        gameObject.SetActive(false);
    }
}
