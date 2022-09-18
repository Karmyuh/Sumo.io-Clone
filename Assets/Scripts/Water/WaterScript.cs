using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterScript : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel,_gameWonPanel;
    [SerializeField] TextMeshProUGUI _enemyText;
    [SerializeField] int _enemyCount = 5;
    private void Update()
    {
        if (_enemyCount == 0)
        {
            _gameWonPanel.SetActive(true);
            _enemyCount = 5;
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            _enemyCount -= 1;
            _enemyText.text = "5/" + _enemyCount;
        }
    }
}
