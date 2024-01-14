using Godot;
using System;

public partial class TurretManager : Node3D
{
	[Export]
	public PackedScene turret;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void BuildTurret(Vector3 poistion)
	{
		Node3D new_turret = turret.Instantiate() as Node3D;
		this.AddChild(new_turret);
		new_turret.GlobalPosition = poistion;
	}
}

