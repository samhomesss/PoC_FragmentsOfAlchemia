using UnityEngine;
using UnityEngine.UI;

public class Attack_Button : MonoBehaviour
{
    Button _button;
    UI_PlayerInventory _uiInventory;
    private void Start()
    {
        _button = GetComponent<Button>();
        _uiInventory = FindAnyObjectByType<UI_PlayerInventory>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        _uiInventory.GetComponent<Canvas>().enabled = !_uiInventory.GetComponent<Canvas>().enabled;
        _uiInventory.IsAttack = true;
    }
}
