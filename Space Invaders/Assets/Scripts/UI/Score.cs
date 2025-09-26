using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _endScoreTextLose;
    [SerializeField] private TextMeshProUGUI _endScoreTextWin;
    private int _score = 0;
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        _scoreText.text = "—чет: " + _score.ToString();
        _endScoreTextLose.text = "“вой cчет: " + _score.ToString();
        _endScoreTextWin.text = "“вой cчет: " + _score.ToString();
    }
}
