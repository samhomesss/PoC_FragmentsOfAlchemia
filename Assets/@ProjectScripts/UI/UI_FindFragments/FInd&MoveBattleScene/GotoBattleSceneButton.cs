using UnityEngine;
using UnityEngine.UI;

public class GotoBattleSceneButton : MonoBehaviour
{
    BattleSceneOriginal _battleOriginal;
    BattleSceneLeft _leftScene;
    BattleSceneRight _rightScene;
    BattleSceneUp _upScene;

    Button _button;

    private void Awake()
    {
        _battleOriginal = FindAnyObjectByType<BattleSceneOriginal>();
        _leftScene = FindAnyObjectByType<BattleSceneLeft>();
        _rightScene = FindAnyObjectByType<BattleSceneRight>();
        _upScene = FindAnyObjectByType<BattleSceneUp>();
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        _battleOriginal.gameObject.SetActive(true);
        _leftScene.gameObject.SetActive(false);
        _rightScene.gameObject.SetActive(false);
        _upScene.gameObject.SetActive(false);
    }

}
