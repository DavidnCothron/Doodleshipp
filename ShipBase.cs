using Godot;
using System;

public partial class ShipBase : Node2D
{
	protected Sprite2D shipSprite;
	protected Sprite2D activeSprite;
	protected ShipCharacterBody2D shipCharacterBody2D;
	public bool isActive = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		shipSprite = (Sprite2D)GetNode("ShipCharacterBody2D/ShipSprite");
		activeSprite = (Sprite2D)GetNode("ShipCharacterBody2D/ActiveSprite");
		activeSprite.Visible = false;
		shipCharacterBody2D = (ShipCharacterBody2D)GetNode("ShipCharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		if(isActive) {
			if(Input.IsActionPressed("ClickMove")) {
				shipCharacterBody2D.SetTargetPosition();
			}
		}
	}

	public void SetShipActive(bool active) {
		isActive = active;
		activeSprite.Visible = active;
	}
}
