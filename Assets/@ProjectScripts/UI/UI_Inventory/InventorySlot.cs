using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : UI_Scene
{
    public enum GameObjects
    {
        Slot,
    }
    public enum Texts
    {
        SlotText,
    }


    public bool IsEmpty
    {
        get => _isEmpty;
        set
        {
            _isEmpty = value;
        }
    }
    [SerializeField] bool _isEmpty = true; // true 일때 비어 있는거 
    [SerializeField] int _itemID = 0; // 현재 슬롯에서 가지고 있는 itemID 값


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(GameObjects));
        BindTexts(typeof(Texts));
        return true;
    }
}
