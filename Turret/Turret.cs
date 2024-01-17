using Godot;
using System;
using System.Diagnostics;
using System.Linq;

public partial class Turret : Node3D
{
	[Export]
	public PackedScene bullet;
	[Export]
	public float turretRange = 10;

	public Path3D m_enemyPath;

	private Timer timer;
	private Node3D cannon;
	private Node3D cannonPivot;
	private Enemy target;
	private AnimationPlayer m_animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		cannon = GetNode<Node3D>("Base/CannonPivot/Cannon");
        cannonPivot = GetNode<Node3D>("Base/CannonPivot");
        m_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		target = FindBestTarget();
		if(target != null)
		{
			cannonPivot.LookAt(target.GlobalPosition, Vector3.Up, true);
		}
	}

	public void OnTimerTimeOut()
	{
		if(target != null)
		{ 
			bullet new_bullet = bullet.Instantiate<bullet>();
			cannon.AddChild(new_bullet);
			new_bullet.direction = cannon.GlobalTransform.Basis.Z;
			m_animationPlayer.Play("Shoot");
		}
	}

	private Enemy FindBestTarget()
	{
		Enemy best_target = null;
		float best_progress = 0;

		foreach (Node pathObject in m_enemyPath.GetChildren())
		{
			if (pathObject is Enemy enemy)
			{
				if (best_progress < enemy.Progress && this.GlobalPosition.DistanceTo(enemy.GlobalPosition) < turretRange)
				{
					best_progress = enemy.Progress;
					best_target = enemy;
				}
			}
		}

		return best_target;
	}
}
