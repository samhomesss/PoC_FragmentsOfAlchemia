using UnityEngine;
using static Define;

[CreateAssetMenu(menuName = "ScriptableObject / ItemData")]
public class ItemData : ScriptableObject
{
    public int itemID; // 현재 아이템 아이디 값
    public EEnvType itemType; // 현재 아이템의 타입
    public Sprite itemImage; // 현재 아이템 이미지
    public int itemDamage; // 현재 아이템 데미지 
    public int itemShield; // 현재 아이템 방어력 
    public int itemHeal; // 현재 아이템의 힐량
    public string itemName; // 현재 아이템이름 
    [TextArea(10, 100)]
    public string itemInfo; // 아이템 설명 
}
