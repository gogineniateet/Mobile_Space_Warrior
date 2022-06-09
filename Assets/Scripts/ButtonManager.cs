using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject buttonsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LevelUp() //Switch to next level
    {
        SceneManager.LoadScene(2);
    }

    //Settinngs panel to be active
    public void Settings()
    {
        if(settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }

        if(buttonsPanel != null)
        {
            buttonsPanel.SetActive(false);
        }
    }
    //back to settings panel
    public void BackSettingsButton()
    {
        buttonsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    //Back to instructions panel

    public void BackInstructionsButton()
    {
        buttonsPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void Instructions()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);
        }

        if (buttonsPanel != null)
        {
            buttonsPanel.SetActive(false);
        }
    }


}

