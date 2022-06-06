using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] livesimages;
    public Image displaylivesImage;

    public void UpdateLives(int currentLives)
    {
        displaylivesImage.sprite = livesimages[currentLives];
    }

}
