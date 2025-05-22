using UnityEngine;
using UnityEngine.UI;

public class UI_FindFragments : UI_Scene
{
    enum Buttons
    {
        UpArrow,
        LeftArrow,
        RightArrow
    }

    BattleSceneUp _upScene;
    BattleSceneLeft _leftScene;
    BattleSceneRight _rightScene;
    BattleSceneOriginal _originScene;

    Button _upArrow;
    Button _leftArrow;
    Button _rightArrow;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButtons(typeof(Buttons));

        _upScene = FindAnyObjectByType<BattleSceneUp>();
        _rightScene = FindAnyObjectByType<BattleSceneRight>();
        _leftScene = FindAnyObjectByType<BattleSceneLeft>();
        _originScene = FindAnyObjectByType<BattleSceneOriginal>();

        _upScene.gameObject.SetActive(false);
        _rightScene.gameObject.SetActive(false);
        _leftScene.gameObject.SetActive(false);

        _upArrow = GetButton((int)Buttons.UpArrow);
        _leftArrow = GetButton((int)Buttons.LeftArrow);
        _rightArrow = GetButton((int)Buttons.RightArrow);

        _upArrow.onClick.AddListener(GotoUPScene);
        _rightArrow.onClick.AddListener(GotoRightScene);
        _leftArrow.onClick.AddListener(GotoLeftScene);

        return true;
    }

    void GotoUPScene()
    {
        _upScene.gameObject.SetActive(true);
        _originScene.gameObject.SetActive(false);
    }
    void GotoLeftScene()
    {
        _leftScene.gameObject.SetActive(true);
        _originScene.gameObject.SetActive(false);
    }
    void GotoRightScene()
    {
        _rightScene.gameObject.SetActive(true);
        _originScene.gameObject.SetActive(false);
    }
}
