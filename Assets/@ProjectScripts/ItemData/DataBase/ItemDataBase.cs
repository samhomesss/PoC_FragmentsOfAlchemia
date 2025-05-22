using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static Dictionary<int, ItemData> ItemDatas => _itemData;
    static Dictionary<int, ItemData> _itemData = new Dictionary<int, ItemData>();

    private void Awake()
    {
        // 기본 아이템
        AddData(10, "Flower"); // 꽃
        AddData(11, "Rock"); // 진흙

        // 몬스터 재료
        AddData(50, "MonsterBody"); // 붉은 가죽
        AddData(51, "MonsterHead"); // 붉은 머리카락
        AddData(52, "MonsterLeg"); // 붉은 발톱
        AddData(53, "MonsterTail"); // 붉은 꼬리 비늘

        // 조합 아이템 
        AddData(101, "HealPotion"); // 기초 회복약
        AddData(102, "GoodHealPotion"); // 고급 회복약
        AddData(103, "GoodRock"); // 진흙폭탄
        AddData(104, "RedHealPotion"); // 붉은 물약
        AddData(105, "RedBomb"); // 붉은 폭탄
        AddData(106, "RedFlameBomb"); // 화상 폭탄
        AddData(107, "GoodGoodHealPotion"); // 쌉 고급 회복약
        AddData(108, "GodHealPotion"); // 그만 만들어 회복약

        // ✅ 회복 아이템 조합 결과
        AddData(110, "RedSkinPotion"); // 꽃 + 붉은 가죽 → 붉은 물약
        AddData(111, "RedHairPotion"); // 꽃 + 붉은 머리카락 → 강한 회복약
        AddData(112, "RedClawPotion"); // 꽃 + 붉은 발톱 → 상처 회복약
        AddData(113, "RedScalePotion"); // 꽃 + 붉은 가죽 → 재생 물약
        AddData(116, "DoubleScalePotion"); // 붉은 꼬리 비늘 + 붉은 꼬리 비늘 → 비늘갑주 물약

        // 💥 공격 아이템 조합 결과
        AddData(119, "RedHairBomb"); // 진흙 + 붉은 머리카락 → 불꽃 폭탄
        AddData(120, "RedClawBomb"); // 진흙 + 붉은 발톱 → 날카로운 진흙탄
        AddData(121, "RedScaleBomb"); // 진흙 + 붉은 꼬리 비늘 → 비늘탄
        AddData(122, "RedComboBomb"); // 붉은 가죽 + 붉은 머리카락 → 붉은 화염 폭탄
        AddData(123, "ClawScaleBomb"); // 붉은 발톱 + 붉은 꼬리 비늘 → 파열탄
        AddData(124, "HairScaleBomb"); // 붉은 머리카락 + 붉은 꼬리 비늘 → 연소탄
        AddData(125, "DoubleSkinBomb"); // 붉은 가죽 + 붉은 가죽 → 고강도 붉은 폭탄
        AddData(126, "DoubleClawBomb"); // 붉은 발톱 + 붉은 발톱 → 파편탄

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
