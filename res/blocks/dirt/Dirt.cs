using Godot;
using System;

namespace Game.Blocks;
public partial class Dirt : Block
{
    public override string DisplayName => "Dirt";
    public override bool Breakable => true;
    public override bool Dropable => true;
    public override float BaseBreakSpeed => 0.5f;
}
