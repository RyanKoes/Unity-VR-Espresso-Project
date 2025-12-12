using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Make a public text mesh pro tooltip
    
    public TextMeshProUGUI timerText; // Timer Text
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        isTimerRunning = false;
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}