using UnityEngine;

public class Bullet : MonoBehaviour, IDamageble
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
        Check();
        MoveBullet();
    }
    public void Init(int damage, float speed, float lifeTime)
    {
        _damage = damage;
        _speed = speed;
        _lifeTime = lifeTime;
        _logic = new BulletLogic(_speed, _damage, _hitLayerMask, _dir, _previousStep);
    }
    public virtual void MoveBullet()
    {
        Vector2 moveVector = _logic.CalculateMovement(Time.fixedDeltaTime);
        transform.Translate(moveVector);
    }
    public void Check()
    {
        if (CheckHit())
        {
            Destroy(gameObject);
        }
    }
    public bool CheckHit()
    {
        float distance = Vector2.Distance(_previousStep, transform.position);
        RaycastHit2D hit = Physics2D.CircleCast(_previousStep, transform.localScale.x / 2, _dir, distance, _hitLayerMask);
        if (hit && hit.collider.gameObject != gameObject)
        {
            if (hit.collider.TryGetComponent(out IDamageble damageble))
            {
                damageble.TakeDamage(_damage);
                return true;
            }
            return true;
        }
        _previousStep = transform.position;
        return false;
    }
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
