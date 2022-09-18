using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject _pauseButton,_pausePanel,_gameWonPanel;
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] float _time = 50;

    private void Update()
    {
        TimeUpdate();
    }

    public void TimeUpdate()
    {
        _time -= Time.deltaTime;
        _timeText.text = "Time = " + ((int)_time);
        if (_time <= 0)
        {
            Time.timeScale = 0;
            _gameWonPanel.SetActive(true);

        }
    }

    public void PauseButtonOnClick()
    {
        Time.timeScale = 0;
        _pauseButton.SetActive(false);
        _pausePanel.SetActive(true);
    }
    public void PausePanelButtonOnClick()  
    {
        Time.timeScale = 1;
        _pauseButton.SetActive(true);
        _pausePanel.SetActive(false);
    }

    public void ResumeButtonOnClick()
    {
        Time.timeScale = 1;
        _pauseButton.SetActive(true);
        _pausePanel.SetActive(false);
    }
    public void ExitButtonOnClick()
    {
        Application.Quit();
    }
    public void RestartButtonOnClick()
    {
        
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        _time = 50;
        
    }


}
