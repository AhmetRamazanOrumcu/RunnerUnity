using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuickMenuManager : MonoBehaviour
{
    
    public Button restartButton;
    public Button quitButton;
    //public Button stopButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);

    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("SampleScene");
    }
    public void StopGame()
    {
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
