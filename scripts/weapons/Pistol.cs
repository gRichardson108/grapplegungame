using System;
using Godot;
using GrapplegunGame.scripts.weapons;

public class Pistol : Weapon
{
	private AnimationPlayer animationPlayer;
	private PackedScene bulletScene = GD.Load<PackedScene>("res://weapons/Bullet.tscn");

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void PrimaryFire()
	{
		animationPlayer.Play("shoot");
		Spatial bullet = (Spatial) bulletScene.Instance();
		GetTree().Root.AddChild(bullet);
		bullet.GlobalTransform = this.GlobalTransform.Translated(new Vector3(0f, 0f, -10f));
		bullet.Scale = new Vector3(4, 4, 4);
	}

	public override void Reload()
	{
		throw new NotImplementedException();
	}

	public override void SecondaryFire()
	{
		throw new NotImplementedException();
	}

	public override void TertiaryFire()
	{
		throw new NotImplementedException();
	}
}
