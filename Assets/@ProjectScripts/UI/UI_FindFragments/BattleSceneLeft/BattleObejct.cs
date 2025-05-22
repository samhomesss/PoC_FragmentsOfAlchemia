using UnityEngine;
using UnityEngine.UI;

public class BattleObejct : MonoBehaviour
{
    Button _button;

    public int itemID;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        Managers.Game.GetItem(itemID);
        Destroy(gameObject);
    }
}
