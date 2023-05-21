using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    private int _finalScore;
    private float _interval = 1f;
    [SerializeField] private Text _scoretext;
    [SerializeField] private Text _finalScoreText;

    [SerializeField] private GameObject _scoreBar;
    [SerializeField] private GameObject _gameoverMenu;
    private float _increaseScore;
    private PlayerController _player;

    private void Start()
    {
        _increaseScore = _interval;
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _scoreBar.SetActive(true);
        _gameoverMenu.SetActive(false);

    }

    private void Update()
    {
        IncreaseScoreOverTime();
    }

    void IncreaseScoreOverTime()
    {

        _increaseScore -= Time.deltaTime;

        if (_increaseScore <= 0 && !_player._isGameOver)
        {
            _score++;
            UpdateScoreText();
            _increaseScore = _interval;

        }
        else if (_player._isGameOver)
        {
            StartCoroutine(ShowFinalScore());
        }

    }
    IEnumerator ShowFinalScore()
    {
        yield return new WaitForSeconds(2.5f);
        _scoreBar.SetActive(false);
        _gameoverMenu.SetActive(true);

        _finalScore = _score;
        _finalScoreText.text = "Final Scores: " + _finalScore.ToString();
    }
    void UpdateScoreText()
    {
        _scoretext.text = "Scores: " + _score.ToString();
    }

}
