using Godot;
using System;

public partial class VictoryLayer : CanvasLayer
{
	private TextureRect m_star1;
    private TextureRect m_star2;
    private TextureRect m_star3;
	private Label m_healthLabel;
	private Label m_goldLabel;
	private Base m_base;
	private Bank m_bank;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		m_star1 = GetNode<TextureRect>("%Star1");
		m_star2 = GetNode<TextureRect>("%Star2");
		m_star3 = GetNode<TextureRect>("%Star3");
		m_healthLabel = GetNode<Label>("%HealthLabel");
		m_goldLabel = GetNode<Label>("%GoldLabel");
		m_base = (Base)GetTree().GetFirstNodeInGroup("base");
        m_bank = (Bank)GetTree().GetFirstNodeInGroup("bank");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnRetryButtonPressed()
	{
		GetTree().ReloadCurrentScene();
	}

	public void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}

	public void Victory()
	{
		this.Show();
		if (m_base.max_health == m_base.health)
		{
			m_star2.Modulate = Colors.White;
			m_healthLabel.Show();
		}
		if(m_bank.Gold > 500)
		{
            m_star3.Modulate = Colors.White;
			m_goldLabel.Show();
        }
	}
}
