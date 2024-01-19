using Godot;
using System;

public partial class DifficultyManager : Node
{
	[Export]
	public float gameLength = 30;
	[Export]
	public Curve spawnTimeCurve;
    [Export]
    public Curve enemyHealthCurve;

	[Signal]
	public delegate void StopSpawningEnemiesEventHandler();

    private Timer m_timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		m_timer = GetNode<Timer>("Timer");
		m_timer.Start(gameLength);
		Engine.TimeScale = 5;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private float GameProgressRatio()
	{
		return (1.0f - (float)m_timer.TimeLeft / gameLength);
	}

	public float GetSpawnTime()
	{
		return spawnTimeCurve.Sample(GameProgressRatio());
	}

	public float GetEnemyHealth()
	{
		return enemyHealthCurve.Sample(GameProgressRatio());
	}

	public void OnTimerTimeOut()
	{
		EmitSignal(SignalName.StopSpawningEnemies);
	}
}
