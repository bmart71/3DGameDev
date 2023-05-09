using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI gameOverText;
    public void GameOver()
    {
        player.GetComponent<PlayerController>().enabled = false;
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
