using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager Instance;

    public List<Item> Items;

    public Sprite[] ItemSprites;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        GenerateItems();
    }

    private void GenerateItems()
    {
        Items = new List<Item>();

        // Wood
        Items.Add(new Item("Wood", ItemSprites[0]));

        // Wooden Planks
        var woodenPlanksRecipe = new Item[,]
        {
            { Items[0] }
        };
        Items.Add(new Item("Wooden Planks", ItemSprites[1], new CraftRecipe(woodenPlanksRecipe, 4)));

        // Wooden Stick
        var woodenStickRecipe = new Item[,]
        {
            { Items[1] },
            { Items[1] }
        };
        Items.Add(new Item("Wooden Stick", ItemSprites[2], new CraftRecipe(woodenStickRecipe, 4)));

        // Coal
        Items.Add(new Item("Coal", ItemSprites[3]));

        // Torch
        var torchRecipe = new Item[,]
        {
            { Items[3] },
            { Items[2] },
        };
        Items.Add(new Item("Torch", ItemSprites[4], new CraftRecipe(torchRecipe, 4)));

        // Diamond
        Items.Add(new Item("Diamond", ItemSprites[5]));

        // Diamond Axe
        var diamondAxeRecipe = new Item[,]
        {
            { Items[5], Items[5] },
            { Items[5], Items[2] },
            { null,     Items[2] },
        };
        Items.Add(new Item("Diamond Axe", ItemSprites[6], new CraftRecipe(diamondAxeRecipe, 1)));
    }
}
