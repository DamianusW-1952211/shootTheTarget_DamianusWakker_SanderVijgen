using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;
    public float countdownDuration = 60.0f; // Set your desired countdown duration in seconds.
    private float currentTime;
    private bool isCountdownComplete = false;
    private bool timerStarted = false;

    public void Start()
    {
    }

    private void Update()
    {
        if (timerStarted)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                currentTime = 0;
                isCountdownComplete = true;
                // Handle countdown completion, e.g., trigger an event or end the game.
            }
        }
    }

    public void StartTimer()
    {
        currentTime = countdownDuration;
        timerStarted = true;
        isCountdownComplete = false;
        UpdateTimerText();
    }

    public bool IsCountdownComplete
    {
        get { return isCountdownComplete; }
    }

    private void UpdateTimerText()
    {
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = "Time: " + seconds.ToString("D2"); // Display seconds with leading zeros.
    }
}