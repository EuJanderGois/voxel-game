using Game.Entities;
using Godot;
using System;
using System.Collections.Generic;

public abstract partial class GameInstance
{
    public abstract List<Player> Players { get; protected set; }
}