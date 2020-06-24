using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
        //AdManager.instance.ShowFullScreenAd();
        //AdManager.instance.RequestFullScreenAd();
    }
}
