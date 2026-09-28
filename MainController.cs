using Godot;
using System;
using System.Diagnostics;

public partial class MainController : Camera2D
{
	private ShipBase activeShip;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if(Input.IsActionJustPressed("Click")) {
			SetActiveShip();
		}
	}

	private ShipBase CheckIfShipClicked() {
		var spaceState = GetWorld2D().DirectSpaceState;
		var query = new PhysicsPointQueryParameters2D {
			Position = GetGlobalMousePosition(),
			CollideWithBodies = true
		};
		var results = spaceState.IntersectPoint(query);

		foreach(var hit in results) {
			if(hit["collider"].As<Node>() is ShipCharacterBody2D body && body.GetParent() is ShipBase ship) {
				return ship;
			}
		}

		return null;
	}

	private void SetActiveShip() {
		if(activeShip is not null) {
			activeShip.SetShipActive(false);
			activeShip = null;
		}

		var shipBase = CheckIfShipClicked();
		if(shipBase is not null) {
			activeShip = shipBase;
			activeShip.SetShipActive(true);
		}
	}
}
