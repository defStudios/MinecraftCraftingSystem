using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    private Image itemImage;
    private Text itemAmount;

    private Color defaultColor = new Color32(140, 140, 140, 255);
    private Color highlightedColor = new Color32(121, 121, 121, 255);

    public ItemInSlot Item { get; private set; }

    public bool HasItem => Item != null;

    private void Awake()
    {
        image = GetComponent<Image>();
        itemImage = transform.GetChild(0).GetComponent<Image>();
        itemAmount = transform.GetChild(1).GetComponent<Text>();

        itemImage.preserveAspect = true;
    }

    public void SetItem(ItemInSlot item)
    {
        Item = item;
        RefreshUI();
    }

    public void AddItem(ItemInSlot item, int amount)
    {
        item.Amount -= amount;

        if (!HasItem)
            SetItem(new ItemInSlot(item.Item, amount));
        else
        {
            Item.Amount += amount;
            RefreshUI();
        }
    }

    public void ResetItem()
    {
        Item = null;
        RefreshUI();
    }

    protected void RefreshUI()
    {
        itemImage.gameObject.SetActive(HasItem);
        itemImage.sprite = Item?.Item.Sprite;

        itemAmount.gameObject.SetActive(HasItem && Item.Amount > 1);
        itemAmount.text = Item?.Amount.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            LeftClick();
        else
            RightClick();
    }

    public virtual void LeftClick()
    {
        var currItem = InventoryWindow.Instance.CurrentItem;

        if (HasItem)
        {
            if (currItem == null || Item.Item != currItem.Item)
            {
                InventoryWindow.Instance.SetCurrentItem(Item);
                ResetItem();
            }
            else
            {
                AddItem(currItem, currItem.Amount);
                InventoryWindow.Instance.CheckCurrentItem();
                return;
            }
        }
        else
            InventoryWindow.Instance.ResetCurrentItem();

        if (currItem != null)
            SetItem(currItem);
    }

    public virtual void RightClick()
    {
        if (!InventoryWindow.Instance.HasCurrentItem)
            return;

        if (!HasItem || InventoryWindow.Instance.CurrentItem.Item == Item.Item)
        {
            AddItem(InventoryWindow.Instance.CurrentItem, 1);
            InventoryWindow.Instance.CheckCurrentItem();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = highlightedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = defaultColor;
    }
}
