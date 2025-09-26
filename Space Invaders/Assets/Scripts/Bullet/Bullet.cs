using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private float _lifeTime;
    private int _damage;
    [SerializeField] private LayerMask _hitLayerMask;
    [SerializeField] private Vector2 _dir;
    private Vector2 _previousStep;
    private BulletLogic _logic;
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
        _previousStep = transform.position;
    }
    private void FixedUpdate()
    {
        MoveBullet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LayerMaskUtil.ContainsLayer(_hitLayerMask, collision.gameObject))
        {
            if (collision.TryGetComponent(out IDamageble damageble))
            {
                damageble.TakeDamage(_damage);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
    public void Init(int damage, float speed, float lifeTime)
    {
        _damage = damage;
        _speed = speed;
        _lifeTime = lifeTime;
        _logic = new BulletLogic(_speed, _damage, _hitLayerMask, _dir, _previousStep);
    }
    public void MoveBullet()
    {
        transform.Translate(_dir * _speed * Time.fixedDeltaTime);
    }
}
