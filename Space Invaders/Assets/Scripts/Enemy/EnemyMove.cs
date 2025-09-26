using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _timeBeforeMove;
    private void Start()
    {
        StartCoroutine(CDBetweenMove());
    }
    private void Move()
    {
        transform.Translate(-Vector2.up * _distance * Time.deltaTime);
        StartCoroutine(CDBetweenMove());
    }
    private IEnumerator CDBetweenMove()
    {
        yield return new WaitForSeconds(_timeBeforeMove);
        Move();
    }
}
