using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    #region PUBLIC VARIABLES 
    public Text scoreText;
    #endregion
    #region PRIVATE VARIABLES
    private int Kills;
    #endregion

    #region PUBLIC METHOD
    public void ScoreCalculater(int value)
    {
        Kills = Kills + value;
        Debug.Log("Kills :" + Kills);
        scoreText.text = Kills.ToString();

        if(Kills >= 100)
        {
            SceneManager.LoadScene(4);
        }

    }
    #endregion
}
