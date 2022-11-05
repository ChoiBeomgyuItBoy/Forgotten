using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button quitButton;

    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        reloadButton.onClick.AddListener(ReloadScene);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);

        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
