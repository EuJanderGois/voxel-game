using Godot;
using System;
using Game.Items.Tools;

namespace Game.Blocks;

public class BlockFaces
{
    public MeshInstance3D front;
    public MeshInstance3D back;
    public MeshInstance3D right;
    public MeshInstance3D left;
    public MeshInstance3D up;
    public MeshInstance3D down;

    public BlockFaces(Node3D blockRoot)
    {
        if (!blockRoot.HasNode("./front") ||
            !blockRoot.HasNode("./back") ||
            !blockRoot.HasNode("./left") ||
            !blockRoot.HasNode("./right") ||
            !blockRoot.HasNode("./up") ||
            !blockRoot.HasNode("./down"))
        {
            throw new Exception("Uma ou mais faces do bloco não foram encontradas no nó " + blockRoot.Name);
        }
        else
        {
            this.front = blockRoot.GetNode<MeshInstance3D>("./front");
            this.back = blockRoot.GetNode<MeshInstance3D>("./back");
            this.right = blockRoot.GetNode<MeshInstance3D>("./right");
            this.left = blockRoot.GetNode<MeshInstance3D>("./left");
            this.up = blockRoot.GetNode<MeshInstance3D>("./up");
            this.down = blockRoot.GetNode<MeshInstance3D>("./down");
        }
    }
}

/// <summary>
/// Representa um bloco. Todos os blocos do mundo são derivados desta classe.
/// </summary>
public abstract partial class Block : Node3D
{
    /// <summary>
    /// Representa as 6 faces do bloco como MeshInstance3D.
    /// </summary>
    public BlockFaces Faces { get; private set; }

    /// <summary>
    /// Representa o nome visível do bloco.
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// Representa a capacidade de destruição do bloco.
    /// </summary>
    public abstract bool Breakable { get; }

    /// <summary>
    /// Representa a capacidade de obtenção do bloco após a destruição.
    /// </summary>
    public abstract bool Dropable { get; }

    /// <summary>
    /// Representa a velocidade em que o bloco pode ser destruido e pode variar
    /// de acordo com a ferramenta que o jogador possui em sua mão.
    /// </summary>
    public abstract float BaseBreakSpeed { get; }

    public float GetBreakSpeed(ToolType tool)
    {

        float speed = Breakable ? BaseBreakSpeed : 0.0f;

        switch (tool)
        {
            case ToolType.Hand: speed -= 0.1f; break;
            case ToolType.Axe: speed -= 0.2f; break;
            case ToolType.Pickaxe: speed -= 0.2f; break;
            case ToolType.Shovel: speed += 0.2f; break;
            default: speed -= 0.1f; break;
        }

        return MathF.Max(0.0f, speed);
    }

    public override void _Ready()
    {
        Faces = new BlockFaces(this);
    }
}