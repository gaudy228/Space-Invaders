using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamageble
{
    [SerializeField] private int _maxHP;
    private int _hp;
    public Action<int> OnHPChange;
    public Action OnDeadPlayer;
    private void Start()
    {
        _hp = _maxHP;
        OnHPChange?.Invoke(_hp);
    }
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        OnHPChange?.Invoke(_hp);
        if( _hp < 0 )
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
        OnDeadPlayer?.Invoke();
        Debug.Log("dead");
    }
}
