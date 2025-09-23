using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _damageBullet;
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _lifeTimeBullet;
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
       Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
       bullet.Init(_damageBullet, _speedBullet, _lifeTimeBullet);
    }
}