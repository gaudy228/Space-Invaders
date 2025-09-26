using TMPro;
using UnityEngine;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private PlayerHP _playerHP;
    [SerializeField] private PlayerWin _playerWin;
    [SerializeField] private GameObject _deadPanel;
    [SerializeField] private GameObject _winPanel;
    private void Awake()
    {
        _playerHP.OnHPChange += UpdateHPText;
    }
    private void OnEnable()
    {
        _playerHP.OnHPChange += UpdateHPText;
        _playerHP.OnDeadPlayer += DeadPlayer;
        _playerWin.OnWinPlayer += WinPlayer;
    }
    private void OnDisable()
    {
        _playerHP.OnHPChange -= UpdateHPText;
        _playerHP.OnDeadPlayer -= DeadPlayer;
        _playerWin.OnWinPlayer -= WinPlayer;
    }
    private void UpdateHPText(int hp)
    {
        _hpText.text = hp.ToString();
    }
    private void DeadPlayer()
    {
        _deadPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    private void WinPlayer()
    {
        _winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
