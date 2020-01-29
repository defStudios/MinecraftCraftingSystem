public class ItemInSlot
{
    public Item Item { get; private set; }
    public int Amount { get; set; }

    public ItemInSlot(Item item, int amount)
    {
        Item = item;
        Amount = amount;
    }
}
