using Godot;
using System;

public partial class ShipBase : Node2D
{
	protected Sprite2D shipSprite;
	protected CharacterBody2D shipCharacterBody2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		shipSprite = (Sprite2D)GetNode("ShipCharacterBody2D/ShipSprite");
		shipCharacterBody2D = (CharacterBody2D)GetNode("ShipCharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
