using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    #region PRIVATE VARIABLES
    private int Kills;
    #endregion

    #region PUBLIC METHOD
    public void ScoreCalculater(int value)
    {
        Kills = Kills + value;
        Debug.Log("Kills :" + Kills);
    }
    #endregion
}
