using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthPresenter : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Button reloadButton;
    [SerializeField] Button quitButton;

    [SerializeField] float enableCursorDelay;

    void OnEnable()
    {
        reloadButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }


    void Start()
    {
        playerHealth.onHealthChange += UpdateHealthBar;

        playerHealth.onPlayerDead += ShowGameOverCanvas;

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }

    void ShowGameOverCanvas()
    {
        StartCoroutine(EnableUI());
        
        gameOverCanvas.gameObject.SetActive(true);
    }

    IEnumerator EnableUI()
    {
        yield return new WaitForSeconds(enableCursorDelay);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        reloadButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

}
