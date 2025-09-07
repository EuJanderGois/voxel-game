using Godot;
using System;

namespace Game.Items;

public enum ItemType
{
    Tool,
    Weapon,
    Food,
    Placeable
}

public class ItemStack
{
    public int Amount { get; protected set; }
    public int MaxAmount { get; protected set; }
    public Item Item { get; protected set; }
}

public abstract partial class Item
{
    public abstract int Id { get; protected set; }
    public abstract string DisplayName { get; protected set; }
    public abstract ItemType Type { get; protected set; }

    public abstract void Use();
}