using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _damageBullet;
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _lifeTimeBullet;
    [SerializeField] private float _timeBetweenShoot;
    private bool _canShoot = true;
    private Control _control;
    private void Awake()
    {
        _control = new Control();
        _control.Main.PlayerShoot.performed += ctx => Shoot();
    }
    private void OnEnable()
    {
        _control.Enable();
    }
    private void OnDisable()
    {
        _control.Disable();
    }
    private void Shoot()
    {
       if(_canShoot)
       {
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.Init(_damageBullet, _speedBullet, _lifeTimeBullet);
            StartCoroutine(CDBetweenShoot());
       }
    }
    private IEnumerator CDBetweenShoot()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_timeBetweenShoot);
        _canShoot = true;
    }
}