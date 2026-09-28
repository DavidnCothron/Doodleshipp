using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class ShipCharacterBody2D : CharacterBody2D
{
	public const float Speed = 300.0f;
	public float targetPositonDeadzone = 5.0f;
	private Vector2 targetPosition;
	private Queue<Vector2> movementWaypoints = [];


	public override void _Ready()
	{
		targetPosition = Position;
		MotionMode = MotionModeEnum.Floating;
	}

	public override void _PhysicsProcess(double delta)
	{
		var targetWithinDistance = Position.DistanceTo(targetPosition) >= targetPositonDeadzone;

		if(targetWithinDistance) {
			MoveShip(Position.DirectionTo(targetPosition));
		}
	}

	public void SetTargetPosition() {
		targetPosition = GetMovePoint();
	}

	private Vector2 GetMovePoint() {
		return GetGlobalMousePosition();
	}

	private void MoveShip(Vector2 direction) {
		Debug.WriteLine("Ship position is: " + Position);
		Vector2 velocity = Velocity;

		if (direction != Vector2.Zero) {
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
			Rotation = velocity.Angle() + (float)(Math.PI / 2);
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
