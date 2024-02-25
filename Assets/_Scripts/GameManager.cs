using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Stop,
        Win,
        Lose
    }
    public static GameManager instance = null;
    public GameState CurrentState;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void Update()
    {
        CheckGameState();
    }

    private void CheckGameState()
    {
        switch (CurrentState)
        {
            case GameState.Win:
                LoadNextLevel();
                break;
            case GameState.Lose:
                RestartLevel();
                break;
        }
    }

    private void LoadNextLevel()
    {
        int currentStateIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentStateIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Oyun bitti");
        }
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SetGameState(GameState newState)
    {
        CurrentState = newState;
    }
}
