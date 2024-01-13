using Godot;
using System;
using System.Diagnostics;

public partial class Base : Node3D
{
    [Export]
    public int max_health = 5;

    private Label3D m_label;

    public override void _Ready()
    {
        base._Ready();
        m_label = GetNode<Label3D>("Label3D");
        m_label.Text = max_health.ToString();
    }

    public void TakeDamage()
    {
        max_health -= 1;
        m_label.Text = max_health.ToString();
    }
}
