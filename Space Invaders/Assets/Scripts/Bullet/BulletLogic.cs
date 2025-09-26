using UnityEngine;

public class BulletLogic
{
    private float _speed;
    private int _damage;
    private LayerMask _hitLayerMask;
    private Vector2 _dir;
    private Vector2 _previousStep;
    public BulletLogic(float speed, int damage, LayerMask hitLayerMask, Vector2 dir, Vector2 previousStep)
    {
        _speed = speed;
        _damage = damage;
        _hitLayerMask = hitLayerMask;
        _dir = dir;
        _previousStep = previousStep;
    }
    public Vector2 CalculateMovement(float deltaTime)
    {
        return _dir * _speed * deltaTime;
    }
    public bool CheckHit(UnityEngine.Transform curPosition)
    {
        float distance = Vector2.Distance(_previousStep, curPosition.position);
        RaycastHit2D hit = Physics2D.CircleCast(_previousStep, curPosition.localScale.x / 2, curPosition.TransformDirection(-_dir), distance, _hitLayerMask);     
        if (hit)
        {
            if (hit.collider.TryGetComponent(out IDamageble damageble))
            {
                damageble.TakeDamage(_damage);
                return true;
            }
            return true;
        }
        _previousStep = curPosition.position;
        return false;   
    }
}
