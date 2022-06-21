using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCondition : MonoBehaviour
{
    public int scores;
    public int livesLeft;
    public Text scoresText;
    public GameObject allEnemies;

    public void UpdateScores()
    {
        scores++;
        scoresText.text = scores.ToString();
        if (!IsThereAnyEnemyLeft())
        {
            End(true);
        }
    }

    bool IsThereAnyEnemyLeft()
    {
        return allEnemies.transform.childCount > 1;     //Checking if number of enemies is greater than 1, because after that last emeny will be destroyed
    }

    public void End(bool didIWin)
    {
        GlobalVariables.scores = scores;
        GlobalVariables.win = didIWin;
        SceneManager.LoadScene("GameOver");
    }
}
