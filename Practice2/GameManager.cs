using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lives = 10;
    public TextMeshProUGUI livesText, gameOverText;
    public GameObject player, key;
    IEnumerator livesCountdown, showkey;
    void Start()
    {
        livesText.SetText("HP: " + lives);
        livesCountdown = LivesCountdown();
        showkey = ShowKey();
        StartCoroutine(livesCountdown);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            showkey = ShowKey();
            key.gameObject.SetActive(true);
            StartCoroutine(showkey);
        }
    }
    IEnumerator ShowKey()
    {
        yield return new WaitForSeconds(3);
        key.gameObject.SetActive(false);
    }
    IEnumerator LivesCountdown()
    {
        while (lives > 0)
        {
            yield return new WaitForSeconds(2);
            lives--;
            livesText.SetText("HP: "+lives);
        }
        GameOver();
    }

    void GameOver()
    {
        //Time.timeScale = 0;
        StopCoroutine(livesCountdown);
        StopCoroutine(showkey);
        gameOverText.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
    }
    void StopCoroutines()
    {
        StopCoroutine(showkey);
        StopCoroutine(livesCountdown);
    }
    public int getLives()
    {
        return lives;
    }

    public void setLives(int l)
    {
        lives = l;
        livesText.SetText("HP: " + lives);
    }
}
