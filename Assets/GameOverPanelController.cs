using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOverPanelController : MonoBehaviour
{
    [SerializeField]TMP_Text coinCountText;

    private void OnEnable()
    {
        coinCountText.text = GameManager.This.GetCoinCount().ToString();
        Time.timeScale = 0;
    }


    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BacktoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
