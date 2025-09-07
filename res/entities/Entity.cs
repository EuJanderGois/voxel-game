using Godot;
using System;

namespace Game.Entities;

/// <summary>
/// <code>Class</code>
/// Representa uma entidade. Qualquer entidade no mundo herda as propriedades de entidade.
/// </summary>
public abstract partial class Entity
{
    /// <summary>
    /// <code>Class Property</code>
    /// Representa o identificador único da entidade.
    /// </summary>
    public string Uid { get; private set; }

    /// <summary>
    /// <code>Class Property</code>
    /// Representa o nome visível da entidade.
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// <code>Class Property</code>
    /// Representa a vida da entidade.
    /// </summary>
    public abstract float Health { get; protected set; }

    /// <summary>
    /// <code>Class Property</code>
    /// Representa a vida máxima da entidade.
    /// </summary>
    public abstract float MaxHealth { get; protected set; }

    /// <summary>
    /// <code>Class Property</code>
    /// Representa o nível de fome da entidade.
    /// </summary>
    public abstract float Food { get; }

    /// <summary>
    /// <code>Class Property</code>
    /// Representa o nível de experiencia da entidade.
    /// </summary>
    public abstract float Experience { get; protected set; }

    /// <summary>
    /// <code>Class Property</code>
    /// Representa a localização da entidade.
    /// </summary>
    public abstract Vector3I Location { get; }

    /// <summary>
    /// <code>Class Method</code>
    /// Método responsável por mover a entidade.
    /// </summary>
    public abstract void Move(Vector3I newLocation);

    /// <summary>
    /// <code>Class Method</code>
    /// Método responsável por remover a entidade.
    /// </summary>
    public abstract void Destroy();

    /// <summary>
    /// <code>Class Method</code>
    /// Método responsável por aplicar dano a entidade.
    /// </summary>
    /// <param name="damageAmount">parametro que define a quantidade de dano.</param>
    public void Damage(float damageAmount)
    {
        if (this.Health > 0)
        {
            this.Health -= damageAmount;
        }
    }

    /// <summary>
    /// <code>Class Method</code>
    /// Método responsável por curar a entidade.
    /// </summary>
    /// <param name="healAmount">Parametro que define a quantidade de cura.</param>
    public void Heal(float healAmount)
    {
        if (this.Health > 0 &&
        this.Health < this.MaxHealth)
        {
            this.Health += healAmount;
        }
    }

    /// <summary>
    /// <code>Class Method</code>
    /// Método responsável por adicionar experiencia a entidade.
    /// </summary>
    /// <param name="experienceAmount">Parametro que define a quantidade de experiencia.</param>
    public void AddExperience(float experienceAmount)
    {
        this.Experience += experienceAmount;
    }

}