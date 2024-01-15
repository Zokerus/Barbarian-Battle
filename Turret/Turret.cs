using Godot;
using System;
using System.Diagnostics;
using System.Linq;

public partial class Turret : Node3D
{
	[Export]
	public PackedScene bullet;

	public Path3D m_enemyPath;

	private Timer timer;
	private MeshInstance3D turretTop;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		turretTop = GetNode<MeshInstance3D>("Base/Top");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var enemy = m_enemyPath.GetChildren()[^1]; //getting the last item of the array
	}

	public void OnTimerTimeOut()
	{
		Area3D new_bullet = bullet.Instantiate<Area3D>();
		turretTop.AddChild(new_bullet);
	}
}
