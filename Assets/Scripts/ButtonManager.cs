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
    public void LevelUp()
    {
        SceneManager.LoadScene(2);
    }


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

    public void BackSettingsButton()
    {
        settingsPanel.SetActive(false);

        if (buttonsPanel != null)
        {
            buttonsPanel.SetActive(true);
        }
    }

    public void BackInstructionsButton()
    {
        // instructionsPanel.SetActive(false);
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

