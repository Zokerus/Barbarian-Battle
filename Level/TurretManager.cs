using Godot;
using System;

public partial class TurretManager : Node3D
{
	[Export]
	public PackedScene turret;
	[Export]
	public Path3D enemyPath;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public void BuildTurret(Vector3 poistion)
	{
		Turret new_turret = turret.Instantiate() as Turret;
		this.AddChild(new_turret);
		new_turret.GlobalPosition = poistion;
		new_turret.m_enemyPath = enemyPath;
	}
}

