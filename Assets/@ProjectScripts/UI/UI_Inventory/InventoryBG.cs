using System.Collections.Generic;
using UnityEngine;

public class InventoryBG : UI_Scene
{
    public List<GameObject> InventoryList => _inventoryList;
    [SerializeField] List<GameObject> _inventoryList;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        return true;
    }

   
}
