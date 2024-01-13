using Godot;
using System;

public partial class Enemy : PathFollow3D
{
	[Export]
	public float speed = 5.0f;

	private Base m_base;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		m_base = (Base)GetTree().GetFirstNodeInGroup("base");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Progress = this.Progress + speed * (float)delta;

		if (this.ProgressRatio > 0.99f)
		{
			m_base.TakeDamage();
			SetProcess(false);
		}
	}
}
