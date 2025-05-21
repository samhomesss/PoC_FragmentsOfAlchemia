using UnityEngine;
using UnityEngine.UI;

public class GetTailButton : MonoBehaviour
{
    Button _button;
    Canvas _uiCanvas;
    private void Start()
    {
        _button = GetComponent<Button>();
        _uiCanvas = FindAnyObjectByType<UI_MonsterAlchemia>().GetComponent<Canvas>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        _uiCanvas.enabled = false;
        Managers.Game.GetItem(53); // 몬스터 머리에 맞는 값으로 변환 해야됨 
    }
}
