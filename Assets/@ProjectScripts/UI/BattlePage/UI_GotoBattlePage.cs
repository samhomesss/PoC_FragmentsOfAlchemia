using UnityEngine;
using UnityEngine.UI;

public class UI_GotoBattlePage : UI_Scene
{
    enum Buttons
    {
        GotoBattlePage,
    }

    Button _gotoBattle;
    Canvas _canvas;

    BattlePage _battlePage;
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButtons(typeof(Buttons));

        _canvas = GetComponent<Canvas>();
        _battlePage = FindAnyObjectByType<BattlePage>();
        _battlePage.gameObject.SetActive(false);

        _gotoBattle = GetButton((int)Buttons.GotoBattlePage);
        _gotoBattle.onClick.AddListener(GotoBattleClick);

        return true;
    }

    void GotoBattleClick()
    {
        _battlePage.gameObject.SetActive(true);
        _canvas.enabled = false;
    }
}
