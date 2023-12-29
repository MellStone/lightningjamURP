using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;


public class GameTimer : MonoBehaviour
{
    public delegate void MinutePassed();
    public static event MinutePassed OnMinutePassed;

    public TMP_Text timerText; // ������ �� ������ Text � UI
    private float elapsedTime = 0f;

    private void Update()
    {
        // ��������� ��������� �����
        elapsedTime += Time.deltaTime;
        // ��������� ����� � UI
        UpdateTimerText();

        if (Mathf.FloorToInt(elapsedTime / 60f) > 0)
        {
            elapsedTime = 0f;
            NotifyMinutePassed();
        }
    }

    private void UpdateTimerText()
    {
        // ����������� �����
        string formattedTime = FormatTime(elapsedTime);

        // ��������� ����� � UI
        timerText.text = "Time: " + formattedTime;
    }

    // ������� ��� �������������� ������� � ������:�������
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
