using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;


public class GameTimer : MonoBehaviour
{
    public delegate void MinutePassed();
    public static event MinutePassed OnMinutePassed;

    public TMP_Text timerText; // Ссылка на объект Text в UI
    private float elapsedTime = 0f;

    private void Update()
    {
        // Обновляем прошедшее время
        elapsedTime += Time.deltaTime;
        // Обновляем текст в UI
        UpdateTimerText();

        if (Mathf.FloorToInt(elapsedTime / 60f) > 0)
        {
            elapsedTime = 0f;
            NotifyMinutePassed();
        }
    }

    private void UpdateTimerText()
    {
        // Форматируем время
        string formattedTime = FormatTime(elapsedTime);

        // Обновляем текст в UI
        timerText.text = "Time: " + formattedTime;
    }

    // Функция для форматирования времени в минуты:секунды
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
