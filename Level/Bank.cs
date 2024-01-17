using Godot;
using System;

public partial class Bank : MarginContainer
{
	[Export]
	public int startingGold = 150;

	private int m_gold;
	private Label m_goldLabel;

	public int Gold
	{
		get { return m_gold; }
		set
		{ 
			m_gold = Math.Max(value, 0);
			m_goldLabel.Text = "Gold: " + m_gold.ToString();
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		m_goldLabel = GetNode<Label>("GoldLabel");
		Gold = startingGold;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
