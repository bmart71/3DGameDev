using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Pedestrian;
    public GameObject gameOverText;
    public TextMeshProUGUI timer;
    private int seconds = 0;
    private int minutes = 0;
    void Start()
    {
        StartCoroutine(WaitForPed());
        StartCoroutine(TimerCoroutine());
    }
    IEnumerator WaitForPed()
    {
        yield return new WaitForSeconds(3);
        Pedestrian.GetComponent<PedestrianController>().enabled = true;
    }

    IEnumerator TimerCoroutine()
    {
        while (true) { 
            yield return new WaitForSeconds(1);
            seconds++;
            if (seconds == 60)
            {
                seconds -= 60;
                minutes++;
            }
            if (seconds < 10) { 
                timer.SetText(minutes + ":0" + seconds);
            } else
            {
                timer.SetText(minutes + ":" + seconds);
            }
        }
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0;
    }
}
