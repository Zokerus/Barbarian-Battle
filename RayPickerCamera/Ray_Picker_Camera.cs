using Godot;
using System;
using System.Diagnostics;

public partial class Ray_Picker_Camera : Camera3D
{
	[Export]
	public TurretManager turretMananger;

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
        
        if (m_rayCast.IsColliding()) 
		{
			Input.SetDefaultCursorShape(Input.CursorShape.PointingHand);
			GodotObject collider = m_rayCast.GetCollider();
			if (collider is GridMap gridMap)
			{
				if(Input.IsActionPressed("click"))
				{
					Vector3 collisionPoint = m_rayCast.GetCollisionPoint();
					Vector3I cell = gridMap.LocalToMap(collisionPoint);
					if (gridMap.GetCellItem(cell) >= 0)
					{
						gridMap.SetCellItem(cell, 1);
						turretMananger.BuildTurret(gridMap.MapToLocal(cell));
					}
				}
            }
		}
		else
		{
            Input.SetDefaultCursorShape(Input.CursorShape.Arrow);
        }
	}
}
