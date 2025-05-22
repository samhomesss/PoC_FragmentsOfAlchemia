using System.Collections.Generic;
using UnityEngine;

//TODO : I 키를 눌렀을때는 연금 행동으로 행동 버튼을 눌렀을때는 행동으로 적용 되도록 설정 

public class UI_PlayerInventory : UI_Scene
{
    // 조합 정보를 담는 Dictionary
    private Dictionary<(int, int), int> _combineTable = new();

    private void InitCombineTable()
    {
        #region 회복초 조합
        _combineTable.Add((10, 10), 102); // 꽃 + 꽃 = 고급 회복약
        _combineTable.Add((10, 11), 101); // 꽃 + 진흙 = 회복약
        _combineTable.Add((10, 52), 112); // 꽃 + 붉은 발톱 → 상처 회복약
        _combineTable.Add((10, 53), 104); // 꽃 + 붉은 꼬리비늘 = 붉은 물약
        _combineTable.Add((10, 51), 111); // 꽃 + 붉은 머리카락 → 강한 회복약
        _combineTable.Add((10, 50), 113); // 꽃 + 붉은 가죽 → 재생 물약
        #endregion

        #region 진흙 조합
        _combineTable.Add((11, 10), 101); // 진흙 + 꽃 = 회복약
        _combineTable.Add((11, 11), 103); // 진흙 + 진흙 = 진흙 폭탄
        _combineTable.Add((11, 50), 105); // 진흙 + 붉은 가죽 = 붉은 폭탄
        _combineTable.Add((11, 51), 119); // 진흙 + 붉은 머리카락 → 불꽃 폭탄
        _combineTable.Add((11, 52), 120); // 진흙 + 붉은 발톱 → 날카로운 진흙탄
        _combineTable.Add((11, 53), 121); // 진흙 + 붉은 꼬리 비늘 → 비늘탄
        #endregion

        #region 몬스터 소재 조합
        _combineTable.Add((51, 51), 106); // 붉은 머리카락 + 붉은 머리카락 = 화상폭탄
        _combineTable.Add((53, 53), 116); // 붉은 꼬리 비늘 + 붉은 꼬리 비늘 → 비늘갑주 물약
        _combineTable.Add((50, 51), 122); // 붉은 가죽 + 붉은 머리카락 → 붉은 화염 폭탄
        _combineTable.Add((52, 53), 123); // 붉은 발톱 + 붉은 꼬리 비늘 → 파열탄
        _combineTable.Add((51, 53), 124); // 붉은 머리카락 + 붉은 꼬리 비늘 → 연소탄
        _combineTable.Add((50, 50), 125); // 붉은 가죽 + 붉은 가죽 → 고강도 붉은 폭탄
        _combineTable.Add((52, 52), 126); // 붉은 발톱 + 붉은 발톱 → 파편탄
        #endregion

        #region 고급 회복약 조합
        _combineTable.Add((102, 102), 107); // 고급 회복약 + 고급 회복약 = 쌉 고급 회복약
        _combineTable.Add((107, 107), 108); // 쌉고급 회복약 + 쌉고급 회복약 = 그만 만들어 회복약
        #endregion
    }

    #region UnData
    enum GameObjects
    {
        InventoryBG,
    }

    /// <summary>
    /// 연금 버튼 일땐 false 행동일땐 true
    /// </summary>
    public bool IsAttack
    {
        get => _isAttack;
        set
        {
            _isAttack = value;
        }
    }
    [SerializeField] bool _isAttack = false;

    List<GameObject> _inventoryList;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(GameObjects));

        Managers.Game.OnGetItemEvent += GetItemInventory; // 아이템 먹은거 표시 
        InitCombineTable();
        return true;
    }

    private void Start()
    {
        _inventoryList = GetObject((int)GameObjects.InventoryBG).GetComponent<InventoryBG>().InventoryList;
    }

    InventorySlotImage _firstSlot = null;

    /// <summary>
    /// 조합할 때 사용하는 함수 
    /// </summary>
    /// <param name="clickedSlot"></param>
    public void OnAlchemySlotClicked(InventorySlotImage clickedSlot)
    {
        if (_firstSlot == null)
        {
            _firstSlot = clickedSlot;
            Debug.Log($"첫 슬롯 선택됨: {clickedSlot.SlotIndex}");
        }
        else if (_firstSlot == clickedSlot)
        {
            Debug.Log("같은 슬롯을 두 번 눌렀습니다. 초기화합니다.");
            _firstSlot = null;
        }
        else
        {
            Debug.Log($"두 슬롯 조합 시작: {_firstSlot.SlotIndex} + {clickedSlot.SlotIndex}");

            // 여기서 조합 로직 수행
            CombineItems(_firstSlot, clickedSlot);

            // 조합 후 초기화
            _firstSlot = null;
        }
    }
    /// <summary>
    /// TODO : 이거 더했을때 같은 번호가 나오면 그 번호로 고정 해야 할 듯?
    /// </summary>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    void CombineItems(InventorySlotImage slot1, InventorySlotImage slot2)
    {
        int id1 = slot1.slotID;
        int id2 = slot2.slotID;

        if (_combineTable.TryGetValue((id1, id2), out int result) ||
            _combineTable.TryGetValue((id2, id1), out result)) // 양방향 체크
        {
            slot1.slotID = result;
            slot2.slotID = 0;

            slot1.slotText.text = ItemDataBase.ItemDatas[result].itemName;
            slot2.slotText.text = "";
            slot2.transform.parent.GetComponent<InventorySlot>().IsEmpty = true;

            Debug.Log($"조합 성공: {id1} + {id2} = {result}");
        }
        else
        {
            Debug.Log("조합 불가한 아이템입니다.");
            // TODO: 사용자에게 UI로 '조합 불가' 메시지 보여주기
        }
    }
    // 갯수 증가 
    void GetItemInventory(int itemID)
    {
        foreach (var item in _inventoryList)
        {
            if (item.GetComponent<InventorySlot>().IsEmpty)
            {
                item.GetComponent<InventorySlot>().IsEmpty = false;
                item.GetComponent<InventorySlot>().GetObject((int)InventorySlot.GameObjects.Slot).GetComponent<InventorySlotImage>().slotID
                    = itemID;
                item.GetComponent<InventorySlot>().GetText((int)InventorySlot.Texts.SlotText).text
                    = ItemDataBase.ItemDatas[itemID].itemName;
                return;
            }
        }
    }
    #endregion
}
