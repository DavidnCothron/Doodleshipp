using Godot;
using System;
using System.Diagnostics;

public partial class ShipCharacterBody2D : CharacterBody2D
{
	public const float Speed = 300.0f;

	public override void _Ready()
	{
		MotionMode = MotionModeEnum.Floating;
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveShip(Input.GetVector("Left", "Right", "Up", "Down"));
	}

	private void MoveShip(Vector2 direction)
	{
		Vector2 velocity = Velocity;

		if (direction != Vector2.Zero)

		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
			Rotation = velocity.Angle() + (float)(Math.PI / 2);
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
