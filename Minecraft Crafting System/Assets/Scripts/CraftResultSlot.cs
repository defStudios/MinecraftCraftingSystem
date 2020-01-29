using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftResultSlot : Slot
{
    public override void LeftClick()
    {
        if (InventoryWindow.Instance.HasCurrentItem || !InventoryWindow.Instance.CraftController.HasResultItem)
            return;

        InventoryWindow.Instance.SetCurrentItem(Item);
        ResetItem();

        InventoryWindow.Instance.CraftController.CraftItem();
    }
}
