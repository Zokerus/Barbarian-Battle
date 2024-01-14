using Godot;
using System;
using System.Diagnostics;

public partial class Base : Node3D
{
    [Export]
    public int max_health = 5;

    private Label3D m_label;
    private int m_health;

    private int health
    {
        get { return m_health; }
        set
        {
            m_health = value;
            m_label.Text = m_health.ToString();
            if (m_health < 1 )
            {
                GetTree().ReloadCurrentScene();
            }
        }
    }

    public override void _Ready()
    {
        base._Ready();
        m_label = GetNode<Label3D>("Label3D");
        health = max_health;
    }

    public void TakeDamage()
    {
        health -= 1;
    }
}
