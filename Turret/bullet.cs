using Godot;
using System;

public partial class bullet : Area3D
{
	[Export]
	public float speed = 30.0f;

	private Vector3 direction = Vector3.Forward;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GlobalPosition = GlobalPosition + direction * speed * (float)delta;
	}

    public void OnTimerTimeOut()
	{
		this.QueueFree();
	}
}
