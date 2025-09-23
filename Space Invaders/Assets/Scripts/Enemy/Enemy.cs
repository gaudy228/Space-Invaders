using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private int _hp;
    [SerializeField] private int _countScore;
    [SerializeField] private Bullet _billet;
    [SerializeField] private int _damageBullet;
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _lifeTimeBullet;
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if(_hp < 0)
        {
            _hp = 0;
        }
        if(_hp == 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        Destroy(gameObject);
    }
    public void Shoot()
    {
        Bullet bullet = Instantiate(_billet, transform.position, Quaternion.identity);
        bullet.Init(_damageBullet, _speedBullet, _lifeTimeBullet);
    }
}
