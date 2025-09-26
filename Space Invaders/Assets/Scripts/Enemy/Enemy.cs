using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private int _hp;
    [SerializeField] private int _countScore;
    [SerializeField] private Bullet _billet;
    [SerializeField] private int _damageBullet;
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _lifeTimeBullet;
    [SerializeField] private LayerMask _goalLayerMask;
    private Score _score;
    private PlayerWin _win;
    private PlayerHP _playerHP;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LayerMaskUtil.ContainsLayer(_goalLayerMask, collision.gameObject))
        {
            _playerHP.OnDeadPlayer?.Invoke();
        }
    }
    public void Init(Score score, PlayerWin win, PlayerHP hp)
    {
        _playerHP = hp;
        _score = score;
        _win = win;
    }
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
        _score.AddScore(_countScore);
        _win.DeadEnemy();
        Destroy(gameObject);
    }
    public void Shoot()
    {
        Bullet bullet = Instantiate(_billet, transform.position, Quaternion.identity);
        bullet.Init(_damageBullet, _speedBullet, _lifeTimeBullet);
    }
}
