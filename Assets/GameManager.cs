using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject killAnimCanvas;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void RestartWithDelay(float delay)
    {
        StartCoroutine(RestartWithDelayCorutine(delay));
    }

    IEnumerator RestartWithDelayCorutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        RestartLevel();
    }

    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            Invoke("ExitGame", 1f);
        }
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        if (killAnimCanvas != null) killAnimCanvas.SetActive(true);

        FindObjectOfType<PlayerLocomotion>().gameObject.SetActive(false);
        AILocomotion[] ais = FindObjectsOfType<AILocomotion>();
        foreach(AILocomotion ai in ais)
            ai.gameObject.SetActive(false);
    }
}
