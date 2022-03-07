using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text EnterNameText;
    public Text BestScoreText;
    public void Start()
    {
        BestScoreText.text = "Best Score: " + MainManager.Instance.HighScoreName + " - " + MainManager.Instance.HighScore;
    }

    public void StartGame()
    {
        if (!string.IsNullOrWhiteSpace(EnterNameText.text))
        {
            MainManager.Instance.PlayerName = EnterNameText.text.ToUpper();
            SceneManager.LoadScene("main");
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
