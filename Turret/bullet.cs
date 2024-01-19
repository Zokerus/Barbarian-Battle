using Godot;
using System;
using System.Diagnostics;

public partial class bullet : Area3D
{
	[Export]
	public float speed = 30.0f;
	[Export]
	public int damage = 25;

	public Vector3 direction = Vector3.Forward;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GlobalPosition = GlobalPosition + direction * speed * (float)delta;
	}

    public void OnTimerTimeOut()
	{
		this.QueueFree();
	}

    public void OnAreaEntered(Area3D area)
    {
		if (area.IsInGroup("enemy_area"))
		{
			Enemy enemy = area.GetParent<Enemy>();
			enemy.health = enemy.health - damage;
			QueueFree();
		}
    }
}
