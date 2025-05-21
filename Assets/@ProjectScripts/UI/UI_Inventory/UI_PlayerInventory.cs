using System.Collections.Generic;
using UnityEngine;

//TODO : I 키를 눌렀을때는 연금 행동으로 행동 버튼을 눌렀을때는 행동으로 적용 되도록 설정 

public class UI_PlayerInventory : UI_Scene
{
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
    void CombineItems(InventorySlotImage index1, InventorySlotImage index2)
    {
        int mixIndex = 0;

        switch (index1.slotID)
        {
            case 10: // 꽃
                switch (index2.slotID)
                {
                    case 10: // 꽃
                        // 고급 회복약
                        mixIndex = 102;
                        break;
                    case 11: // 진흙
                        // 회복약
                        mixIndex = 101;
                        break;
                    case 50: // 붉은 가죽
                        break;
                    case 51: // 붉은 머리카락
                        break;
                    case 52: // 붉은 발톱
                        mixIndex = 107;
                        break;
                    case 53: // 붉은 꼬리비늘
                        mixIndex = 104;
                        break;
                }
                break;
            case 11: // 진흙
                switch (index2.slotID)
                {
                    case 10: // 꽃
                        // 회복약
                        mixIndex = 101;
                        break;
                    case 11: // 진흙
                        // 진흙 폭탄
                        mixIndex = 103;
                        break;
                    case 50:
                        mixIndex = 105; // 붉은 폭탄
                        break;
                    case 51:
                        mixIndex = 0;
                        break;
                    case 52:
                        mixIndex = 0;
                        break;
                    case 53:
                        mixIndex = 0;
                        break;
                }
                break;
            case 51:
                switch (index2.slotID)
                {
                    case 51:
                        mixIndex = 106;
                        break;
                }
                break;
        }

        if (mixIndex == 0) // TODO: 조합할수 없습니다 문구 띄워주기 
            return;

        index1.slotID = mixIndex;
        index2.slotID = 0;

        index1.slotText.text = ItemDataBase.ItemDatas[index1.slotID].itemName;
        index2.slotText.text = "";
        index2.transform.parent.GetComponent<InventorySlot>().IsEmpty = true;

        Debug.Log($"아이템 조합 완료: {index1} 슬롯에 결과 저장");
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


}
