using UnityEngine;

/// <summary>
/// 환경 요소
/// </summary>
public class EnvObject : BaseObject
{
    Hero _hero;
    public int itemID;
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _hero = FindAnyObjectByType<Hero>();

        return true;
    }

    private void Update()
    {
        float dist = (_hero.transform.position - transform.position).magnitude;
        if (dist < 2f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Managers.Game.GetItem(itemID);
                Destroy(gameObject);
            }
        }
    }
}
