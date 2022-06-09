using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region PUBLIC VARIABLES 
    public Sprite[] livesimages;
    public Image displaylivesImage;
    #endregion

    #region PUBLIC METHODS
    public void UpdateLives(int currentLives)
    {
        displaylivesImage.sprite = livesimages[currentLives];
    }
    #endregion

}
