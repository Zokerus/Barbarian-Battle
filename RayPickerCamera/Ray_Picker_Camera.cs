using Godot;
using System;

public partial class Ray_Picker_Camera : Camera3D
{
	private RayCast3D m_rayCast;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		m_rayCast = GetNode<RayCast3D>("RayCast3D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 mousePos = GetViewport().GetMousePosition();
		m_rayCast.TargetPosition = this.ProjectLocalRayNormal(mousePos) * 100.0f; ;
		m_rayCast.ForceRaycastUpdate();
	}
}
