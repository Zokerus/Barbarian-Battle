using Godot;
using System;

public partial class Enemy : PathFollow3D
{
	[Export]
	public float speed = 5.0f;
	[Export]
	public int max_health = 50;

	private Base m_base;
	private int m_health;
	private AnimationPlayer m_animationPlayer;

	public int health
	{
		get { return m_health; }
		set
		{
			if (value < m_health) 
			{ m_animationPlayer.Play("TakeDamage"); }
			m_health = value;
			if (m_health < 1)
			{
				QueueFree();
			}
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		m_base = (Base)GetTree().GetFirstNodeInGroup("base");
		m_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		health = max_health;
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
