using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private SpawnEnemy _spawnEnemy;
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private PlayerWin _win;
    private void Start()
    {
        StartCoroutine(CDBetweenShoot());
    }
    private void Shoot()
    {
        if (_win.CheckWin())
        {
            return;
        }
        int rnd = Random.Range(0, _spawnEnemy.GridEnemys.GetLength(0));
        if(_spawnEnemy.GridEnemys[rnd, _spawnEnemy.GridEnemys.GetLength(1) - 1] == null)
        {
            Shoot();
        }
        for (int i = 0; i < _spawnEnemy.GridEnemys.GetLength(1); i++)
        {
            if (_spawnEnemy.GridEnemys[rnd, i] != null)
            {
                _spawnEnemy.GridEnemys[rnd, i].Shoot();
                return;
            }
        }
    }
    private IEnumerator CDBetweenShoot()
    {
        Shoot();
        yield return new WaitForSeconds(_timeBetweenShoot);
        StartCoroutine(CDBetweenShoot());
    }
}
