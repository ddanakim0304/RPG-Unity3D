using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;
    public GameObject damagedPanel;
    public GameObject gameOverPanel;

    void Start()
    {
        currentHP = maxHP;
        damagedPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void GetHit(int damage)
    {
        damage = Mathf.Clamp(damage, 0, maxHP);
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }

        Debug.Log(currentHP);
        ActivateDamagedPanel();
    }

    private void ActivateDamagedPanel()
    {
        if (damagedPanel != null)
        {
            StartCoroutine(ShowDamagedPanel());
        }
    }

    private IEnumerator ShowDamagedPanel()
    {
        damagedPanel.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        damagedPanel.SetActive(false);
    }



     private void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Player died");
        ActivateGameOverPanel();
        PauseGame();
    }

    private void ActivateGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void PauseGame()
    {
        
        Time.timeScale = 0f; // Pause the game
    }
}
