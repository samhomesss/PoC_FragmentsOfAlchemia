using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static Dictionary<int, ItemData> ItemDatas => _itemData;
    static Dictionary<int, ItemData> _itemData = new Dictionary<int, ItemData>();

    private void Awake()
    {
        // 기본 아이템
        AddData(10, "Flower");
        AddData(11, "Rock");

        // 몬스터 재료
        AddData(50, "MonsterBody");
        AddData(51, "MonsterHead");
        AddData(52, "MonsterLeg");
        AddData(53, "MonsterTail");

        // 조합 아이템 
        AddData(101, "HealPotion");
        AddData(102, "GoodHealPotion");
        AddData(103, "GoodRock");
        AddData(104, "RedHealPotion");
        AddData(105, "RedBomb");
        AddData(106, "RedFlameBomb");
        AddData(107, "Sheild");

        foreach (var item in _itemData)
        {
            Debug.Log(item.Value);
        }
    }

    void AddData(int itemID , string path)
    {
        if (!_itemData.ContainsKey(itemID))
        {
            _itemData.Add(itemID, Resources.Load<ItemData>($"ItemData/{path}"));
        }
        else
            return;
    }

}
