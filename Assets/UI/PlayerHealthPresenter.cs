using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthPresenter : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] Canvas gameOverCanvas;

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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        gameOverCanvas.gameObject.SetActive(true);
    }

}
