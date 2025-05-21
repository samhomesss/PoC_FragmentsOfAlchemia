using UnityEngine;

/// <summary>
/// 자원 채집해서 하는 걸 테스트 하기 위함임
/// </summary>
public class ItemTester : MonoBehaviour
{
    UI_PlayerInventory _uiInventory;
    UI_MonsterAlchemia _uiMonsterAlchemia;
    private void Start()
    {
        _uiInventory = FindAnyObjectByType<UI_PlayerInventory>();
        _uiMonsterAlchemia = FindAnyObjectByType<UI_MonsterAlchemia>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0)) // 아이템 0 번 획득
        {
            Managers.Game.GetItem(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 아이템 1번 획득 
        {
            Managers.Game.GetItem(11);
        }

        ///  UI 반응형 단축키 
        if (Input.GetKeyDown(KeyCode.Q)) // 연금 단축키
        {
            // TODO : 해당 버튼 눌렀을때 나머지 창도 다 닫겨야 됨. 행동 창도 닫아져야 됨 
            // TODO : 연금 버튼을 눌렀을때도 해당 창을 사용하기 때문에 따로 바꿔 줘야 함 
            if (_uiInventory.GetComponent<Canvas>().enabled && _uiInventory.IsAttack)
            {
                _uiInventory.IsAttack = false;
            }
            else
            {
                _uiInventory.GetComponent<Canvas>().enabled = !_uiInventory.GetComponent<Canvas>().enabled;
                _uiInventory.IsAttack = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) // 행동 단축키 
        {
            // TODO : 해당 버튼 눌렀을때 나머지 창도 다 닫겨야 됨. 행동 창도 닫아져야 됨 
            // TODO : 연금 버튼을 눌렀을때도 해당 창을 사용하기 때문에 따로 바꿔 줘야 함 
            if (_uiInventory.GetComponent<Canvas>().enabled && !_uiInventory.IsAttack)
            {
                _uiInventory.IsAttack = true;
            }
            else
            {
                _uiInventory.GetComponent<Canvas>().enabled = !_uiInventory.GetComponent<Canvas>().enabled;
                _uiInventory.IsAttack = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) // 연금 수확 -> 몬스터에게 뜯어 오기 
        {
            _uiMonsterAlchemia.GetComponent<Canvas>().enabled = !_uiMonsterAlchemia.GetComponent<Canvas>().enabled;
        }

    }
}
