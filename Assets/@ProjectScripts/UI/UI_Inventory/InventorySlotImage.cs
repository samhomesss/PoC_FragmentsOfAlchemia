using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 현재 버튼이 여기 달려서 사용
/// </summary>
public class InventorySlotImage : UI_Scene
{
    Button _button;
    UI_PlayerInventory _uiInventory;
    public int slotID = 0; // 현재 슬롯에 들어가 있는 ID;
    public TMP_Text slotText; // 아이템 이름;
    public int SlotIndex; // 슬롯 번호 (외부에서 할당하거나 자동 부여)


    private void Start()
    {
        _button = GetComponent<Button>();
        _uiInventory = FindAnyObjectByType<UI_PlayerInventory>();
        slotText = GetComponentInChildren<TMP_Text>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        if (_uiInventory.IsAttack) // 공격 행동일 때 
        {
            if (slotID == 0)
                return;

            switch (ItemDataBase.ItemDatas[slotID].itemType)
            {
                case Define.EEnvType.Attack:
                    // 적에게 데미지 
                    Managers.Game.HeroAttack(ItemDataBase.ItemDatas[slotID].itemDamage);
                    break;
                case Define.EEnvType.Heal:
                    // 플레이어 체력 회복 
                    Managers.Game.HeroHeal(ItemDataBase.ItemDatas[slotID].itemHeal);
                    break;
                case Define.EEnvType.Shield:
                    // 플레이어 방어력 증가 
                    break;
            }
            //TODO : 비어 있는걸로 바꿔 줘야 함 
            slotID = 0;
            slotText.text = "";
            transform.parent.GetComponent<InventorySlot>().IsEmpty = true;
            // 이후에 그냥 데미지 들어 오게 설정 해야 할 듯?
            _uiInventory.GetComponent<Canvas>().enabled = false;
            StartCoroutine(EnemyDamaged());
        }
        else // 연금 행동일때
        {
            if (slotID == 0)
                return;
            // 처음 누른 것과 나중에 누른걸 저장 해서 
            // 처음 누른 자리에 두가지를 합친 걸 넣어야 함 
            _uiInventory.OnAlchemySlotClicked(this);
        }
    }

    IEnumerator EnemyDamaged()
    {
        yield return new WaitForSeconds(0.5f);
        Managers.Game.HeroDamaged(10);
    }
}
