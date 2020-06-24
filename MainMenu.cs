using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;
    public void PlayGame()
    {
        
        Application.LoadLevel(playGameLevel);
        //AdManager.instance.HideBanner(); 
         
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
