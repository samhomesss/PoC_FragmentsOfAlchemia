using System;
using UnityEngine;
using static Define;

/// <summary>
/// 게임 중앙 관리 
/// </summary>
public class GameManager
{
    #region Hero
    private Vector2 _moveDir;
    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set
        {
            _moveDir = value;
            OnMoveDirChanged?.Invoke(value);
        }
    }

    private bool _attackAction;
    public bool AttackAction
    {
        get => _attackAction;
        set
        {
            _attackAction = value;
            OnAttackActionEvent?.Invoke(value);
        }
    }

    private EInputSystemState _inputSystemState;
    public EInputSystemState InputSystemState
    {
        get => _inputSystemState;
        set

        {
            _inputSystemState = value;
            OnInputSystemStateChanged?.Invoke(_inputSystemState);
        }
    }
    #endregion

    #region Action
    public event Action<Vector2> OnMoveDirChanged;
    public event Action<bool> OnAttackActionEvent;
    public event Action<Define.EInputSystemState> OnInputSystemStateChanged;

    /// <summary>
    /// UI Action
    /// </summary>
    public event Action<int> OnGetItemEvent; // 아이템 획득에 대한 이벤트 
    public event Action<int> OnHeroAttackEvent; // 플레이어가 적 공격 했을때 발동 할 이벤트
    public event Action<int> OnHeroDamagedEvent; // 플레이어가 공격 당했을때 발동할 이벤트 
    public event Action<int> OnHeroHealEvent; // 플레이어가 회복 햇을때 발동할 이벤트 
    public void GetItem(int itemID)
    {
        OnGetItemEvent?.Invoke(itemID);
    }
    public void HeroAttack(int damage)
    {
        OnHeroAttackEvent?.Invoke(damage);
    }
    public void HeroDamaged(int enemyAttack)
    {
        OnHeroDamagedEvent?.Invoke(enemyAttack);
    }
    public void HeroHeal(int healing)
    {
        OnHeroHealEvent?.Invoke(healing);
    }
    #endregion

    public void DisConnect()
    {
        OnMoveDirChanged = null;
        OnAttackActionEvent = null;
        OnInputSystemStateChanged = null;
    }
}
