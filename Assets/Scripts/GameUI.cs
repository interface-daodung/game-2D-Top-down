using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject gameWinMenu;

    void Start()
    {
        Time.timeScale = 0f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StarGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        gameWinMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void StarPause()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        gameWinMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StarGameOver()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        gameWinMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StarWinMenu()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        gameWinMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StarMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
