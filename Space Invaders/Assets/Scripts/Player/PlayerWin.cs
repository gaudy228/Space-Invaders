using System;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] private SpawnEnemy _spawnEnemy;
    private int _curEnemy;
    public Action OnWinPlayer;
    private void Start()
    {
        _curEnemy = _spawnEnemy.GridEnemys.Length;
    }
    public void DeadEnemy()
    {
        _curEnemy--;
        if (CheckWin())
        {
            OnWinPlayer?.Invoke();
        }
    }
    public bool CheckWin()
    {
        if (_curEnemy == 0)
        {
            return true;
        }
        return false;
    }
}
