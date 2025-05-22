using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : UI_Scene
{
    Slider _enemyHP;
    UI_GameClear _uiGameClear;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _enemyHP = GetComponent<Slider>();
        _uiGameClear = FindAnyObjectByType<UI_GameClear>();
        Managers.Game.OnHeroAttackEvent += EnemyDamaged;
        return true;
    }

    void EnemyDamaged(int damage)
    {
        _enemyHP.value -= damage;
        if (_enemyHP.value <= 0)
        {
            Debug.Log("적이 죽었습니다.");
            //TODO: 게임 클리어 
            _uiGameClear.GetComponent<Canvas>().enabled = true;
        }
    }

}
