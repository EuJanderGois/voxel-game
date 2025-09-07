using Godot;
using System;

namespace Game.Entities;

public partial class Player : CharacterBody3D
{
    [Export] private Camera3D camera;
    [Export] private float moveSpeed = 10f;
    [Export] private float mouseSensitivity = 0.1f;

    private float yaw = 0f;
    private float pitch = 0f;

    private Vector2 mouseDelta = Vector2.Zero; // armazenará delta do mouse a cada frame

    public override void _Ready()
    {
        if (camera == null)
            GD.PrintErr("Camera não atribuída!");

        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("toggle_mouse"))
        {
            if (Input.MouseMode == Input.MouseModeEnum.Captured)
                Input.MouseMode = Input.MouseModeEnum.Visible; // solta o cursor
            else
                Input.MouseMode = Input.MouseModeEnum.Captured; // captura o cursor
        }

        if (Input.MouseMode == Input.MouseModeEnum.Captured)
            UpdateCameraRotation();
        mouseDelta = Vector2.Zero; // reset a cada frame
    }

    public override void _PhysicsProcess(double delta)
    {
        MovePlayer((float)delta);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion motion)
        {
            mouseDelta += motion.Relative; // acumula delta
        }
    }

    private void UpdateCameraRotation()
    {
        yaw -= mouseDelta.X * mouseSensitivity;
        pitch -= mouseDelta.Y * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -89f, 89f);

        RotationDegrees = new Vector3(0f, yaw, 0f); // gira corpo
        camera.RotationDegrees = new Vector3(pitch, 0f, 0f); // gira câmera local
    }

    private void MovePlayer(float delta)
    {
        Vector3 direction = Vector3.Zero;

        if (Input.IsActionPressed("move_forward"))
            direction -= Transform.Basis.Z;
        if (Input.IsActionPressed("move_back"))
            direction += Transform.Basis.Z;
        if (Input.IsActionPressed("move_left"))
            direction -= Transform.Basis.X;
        if (Input.IsActionPressed("move_right"))
            direction += Transform.Basis.X;
        if (Input.IsActionPressed("move_up"))
            direction += Transform.Basis.Y;
        if (Input.IsActionPressed("move_down"))
            direction -= Transform.Basis.Y;

        if (direction != Vector3.Zero)
        {
            direction = direction.Normalized() * moveSpeed;
            Velocity = direction;
            MoveAndSlide();
        }
        else
        {
            Velocity = Vector3.Zero;
        }
    }
}
