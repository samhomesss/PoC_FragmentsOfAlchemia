using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : UI_Scene
{
    Slider _enemyHP;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _enemyHP = GetComponent<Slider>();

        Managers.Game.OnHeroAttackEvent += EnemyDamaged;
        return true;
    }

    void EnemyDamaged(int damage)
    {
        _enemyHP.value -= damage;
    }

}
