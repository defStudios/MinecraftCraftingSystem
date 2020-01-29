using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    public static InventoryWindow Instance;

    public CraftController CraftController;
    public InventoryController InventoryController;

    [SerializeField]
    private Image currentItemImage;

    public ItemInSlot CurrentItem;

    public bool HasCurrentItem => CurrentItem != null;

    private void Awake()
    {
        Instance = this;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        CraftController.Init();
        InventoryController.Init();
    }

    public void SetCurrentItem(ItemInSlot item)
    {
        CurrentItem = item;
        currentItemImage.gameObject.SetActive(true);
        currentItemImage.sprite = CurrentItem.Item.Sprite;
    }

    public void ResetCurrentItem()
    {
        CurrentItem = null;
        currentItemImage.gameObject.SetActive(false);
    }

    public void CheckCurrentItem()
    {
        if (HasCurrentItem && CurrentItem.Amount < 1)
            ResetCurrentItem();
    }

    private void Update()
    {
        if (!HasCurrentItem)
            return;

        currentItemImage.transform.position = Input.mousePosition;
    }
}
