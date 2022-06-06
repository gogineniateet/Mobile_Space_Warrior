using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    #region PRIVATE VARIABLES
    private int score;
    #endregion

    #region PUBLIC METHOD
    public void ScoreCalculater(int value)
    {
        score = score + value;
        Debug.Log(score);
    }
    #endregion
}
