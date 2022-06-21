using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandle : MonoBehaviour
{
    public Text scoresText;
    public Text winOrLoseText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoresText.text = GlobalVariables.scores.ToString();
        if (!GlobalVariables.win) winOrLoseText.text = "You lose!";

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
