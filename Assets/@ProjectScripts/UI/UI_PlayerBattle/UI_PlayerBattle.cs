using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerBattle : UI_Scene
{
    enum Buttons
    {
        Run_Button,
        FindObjectButton,
    }

    Button _runButton;
    Button _findButton;
    UI_FindFragments _uiFindFragments;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButtons(typeof(Buttons));

        _uiFindFragments = FindAnyObjectByType<UI_FindFragments>();

        _runButton = GetButton((int)Buttons.Run_Button);
        _findButton = GetButton((int)Buttons.FindObjectButton);

        //TODO : ButtonPressEvent
        _runButton.onClick.AddListener(RunButtonClick);
        _findButton.onClick.AddListener(FindButtonClick);

        return true;
    }

    void RunButtonClick()
    {
        // TODO : 도망가기 눌렀을때 될거 설정 
    }    
    
    void FindButtonClick()
    {
        // TODO : 방향키 나오도록 
        _uiFindFragments.GetComponent<Canvas>().enabled = !_uiFindFragments.GetComponent<Canvas>().enabled;
    }

}
