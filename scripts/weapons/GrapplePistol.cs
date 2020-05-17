using Godot;
using System;
using GrapplegunGame.scripts.weapons;

public class GrapplePistol : Weapon
{

	private bool IsLoaded { get; set; } = false;

	private PackedScene grappleHookScene = GD.Load<PackedScene>("res://weapons/GrappleHook.tscn");
	private Spatial hookMountPoint;
	private GrappleHook hook = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hookMountPoint = GetNode<Spatial>("Hook_Mount_Point");
	}


	public override void PrimaryFire()
	{
		if (IsLoaded)
		{
			hook.IsLaunched = true;
			hookMountPoint.RemoveChild(hook);
			GetTree().Root.AddChild(hook);
			hook.GlobalTransform = hookMountPoint.GlobalTransform;
			IsLoaded = false;
		}
	}

	public override void Reload()
	{
		if (!IsLoaded)
		{
			hook = (GrappleHook)grappleHookScene.Instance();
			hookMountPoint.AddChild(hook);
			hook.GlobalTransform = hookMountPoint.GlobalTransform;
			IsLoaded = true;
		}
	}

	public override void SecondaryFire()
	{
		throw new NotImplementedException();
	}

	public override void TertiaryFire()
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Called when the grapple hits a solid object, should
	/// initialize the "rope" and allow player to swing, etc.
	/// </summary>
	private void GrappleConnect()
	{

	}
}
