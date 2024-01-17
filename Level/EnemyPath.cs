using Godot;
using System;
using System.Diagnostics;

public partial class EnemyPath : Path3D
{
	[Export]
	public PackedScene enemyScene {  get; set; }
	[Export]
	public DifficultyManager difficultyManager;
	[Export]
	public VictoryLayer victoryLayer;

	private Timer m_spawnTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		m_spawnTimer = GetNode<Timer>("SpawnTimer");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SpawnEnemy()
	{
		Enemy enemy = enemyScene.Instantiate<Enemy>();
		enemy.max_health = (int)difficultyManager.GetEnemyHealth();
		this.AddChild(enemy);
		m_spawnTimer.WaitTime = difficultyManager.GetSpawnTime();
		enemy.TreeExited += EnemyDefeated; 
	}

	public void StopSpawnEnemies()
	{
		m_spawnTimer.Stop(); 
	}

	public void EnemyDefeated()
	{
		if (m_spawnTimer.IsStopped())
		{
			foreach (Node pathObject in this.GetChildren())
			{
				if (pathObject is Enemy enemy)
				{
					return;
				}
			}
			victoryLayer.Victory();
		}
	}
}
