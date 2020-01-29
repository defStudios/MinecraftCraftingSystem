using UnityEngine;

public class Item
{
    public string Name { get; private set; }
    public Sprite Sprite { get; private set; }

    public CraftRecipe Recipe { get; private set; }

    public bool HasRecipe => Recipe != null;

    public Item(string name, Sprite sprite, CraftRecipe recipe = null)
    {
        Name = name;
        Sprite = sprite;
        Recipe = recipe;
    }
}
