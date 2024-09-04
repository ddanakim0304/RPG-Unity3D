using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText; // Reference to the TMP Text component
    private int enemyCount = 0; // Variable to store the count of destroyed enemies

    // This method will be called when an enemy is destroyed
    public void IncrementEnemyCount()
    {
        enemyCount++;
        UpdateEnemyCountUI();
    }

    // Update the UI with the current enemy count
    private void UpdateEnemyCountUI()
    {
        enemyCountText.text = "Enemies Destroyed: " + enemyCount.ToString();
    }
}
