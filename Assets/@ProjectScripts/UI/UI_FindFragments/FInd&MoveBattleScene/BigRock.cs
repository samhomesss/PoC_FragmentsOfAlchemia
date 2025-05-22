using UnityEngine;
using UnityEngine.UI;

public class BigRock : MonoBehaviour
{
    Button _button;
    BattleSceneOriginal _battleScene;
    BattleSceneUp _battleUpScene;
    private void Awake()
    {
        _battleScene = FindAnyObjectByType<BattleSceneOriginal>();
        _battleUpScene = FindAnyObjectByType<BattleSceneUp>();
    }
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        if (_battleScene == null)
            _battleScene = FindAnyObjectByType<BattleSceneOriginal>();

        _battleScene.gameObject.SetActive(true);
        _battleUpScene.gameObject.SetActive(false);
        Managers.Game.HeroAttack(40);
        Destroy(gameObject);
    }
}
