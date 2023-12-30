using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public delegate void MinutePassed();
    public static event MinutePassed OnMinutePassed;

    public TMP_Text timerText;
    private float elapsedTime = 0f;
    private int previousMinute = 0;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();

        int currentMinute = Mathf.FloorToInt(elapsedTime / 60f);

        if (currentMinute > previousMinute)
        {
            previousMinute = currentMinute;
            NotifyMinutePassed();
        }
    }

    private void UpdateTimerText()
    {
        string formattedTime = FormatTime(elapsedTime);
        timerText.text = formattedTime;
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void NotifyMinutePassed()
    {
        OnMinutePassed?.Invoke();
    }
}
