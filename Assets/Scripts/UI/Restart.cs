using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private int stage;
    private void Awake()
    {
       stage = PlayerPrefs.GetInt("Stage", 1);
    }

    public void RestartCurLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoSceneNum(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void GoNextStage()
    {
        stage = Mathf.Clamp(stage + 1, 1, 6);
        if (stage == 6)
        {
            stage = 1;
            PlayerPrefs.SetInt("Stage", stage);
            SceneManager.LoadScene(0);
            return;
        }
        PlayerPrefs.SetInt("Stage", stage);
        SceneManager.LoadScene(stage);
    }

    public void LoadCurrectStage()
    {
        SceneManager.LoadScene(stage);
    }

    public void ResetStages()
    {
        stage = 1;
        PlayerPrefs.SetInt("Stage", stage);
        SceneManager.LoadScene(stage);
    }
}
