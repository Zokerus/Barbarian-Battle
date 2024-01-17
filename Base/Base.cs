using Godot;
using System;
using System.Diagnostics;

public partial class Base : Node3D
{
     [Export]
    public int max_health = 5;

    private Label3D m_label;
    private int m_health;

    public int health
    {
        get { return m_health; }
        set
        {
            m_health = value;
            m_label.Text = m_health.ToString() + "/" + max_health.ToString();
            //m_label.Modulate = Color.Color8(255, (byte)(255 * m_health / max_health), (byte)(255 * m_health / max_health));
            Color red = Colors.Red;
            Color white = Colors.White;
            m_label.Modulate = red.Lerp(white, (float)health / (float)max_health);
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
