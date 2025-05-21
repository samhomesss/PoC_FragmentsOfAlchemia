using UnityEngine.UI;

public class PlayerHP : UI_Scene
{
    Slider _playerHP;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _playerHP = GetComponent<Slider>();

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
    }

}
