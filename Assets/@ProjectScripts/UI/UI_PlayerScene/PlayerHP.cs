using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : UI_Scene
{
    Slider _playerHP;
    UI_GameOver _uiGameOver;
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _playerHP = GetComponent<Slider>();

        _uiGameOver = FindAnyObjectByType<UI_GameOver>();
        Managers.Game.OnHeroHealEvent += HeroHeal;
        Managers.Game.OnHeroDamagedEvent += HeroDamaged;
        return true;
    }

    void HeroHeal(int healing)
    {
        _playerHP.value += healing;
    }

    void HeroDamaged(int damage)
    {
        _playerHP.value -= damage;
        if (_playerHP.value <= 0 )
        {
            // 게임 오버
            _uiGameOver.GetComponent<Canvas>().enabled = true;
        }
    }

}
