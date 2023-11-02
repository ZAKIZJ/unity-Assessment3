using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public Text timeText;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private void Start()
    {
        timeText.text = "00:00:00";
        timerGoing = false;

        BeginTimer();
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss':'ff");
            timeText.text = timePlayingStr;

            yield return null;
        }
    }
}
