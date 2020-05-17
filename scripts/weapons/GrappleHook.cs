using Godot;
using System;
using System.Runtime.CompilerServices;

public class GrappleHook : Spatial
{
	[Export] public float GrappleFlightSpeed { get; set; } = 70.0f;
	[Export] public float Gravity = -24.8f;
	[Export] public float TerminalVelocity = 200.0f;
	// amount of time before bullet disappears
	[Export] public float GrappleFlightTime { get; set; } = 600.0f;

	public bool IsLaunched { get; set; }

	private Vector3 _vel = new Vector3(1f, 1f, 0f);

	// Collision area
	private Area area;

	// flag for eliminating double-collisions when moving at high speed
	private bool hitSomething = false;

	// elapsed time
	private float timer = 0.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Console.WriteLine("Created!");
		area = GetNode<Area>("Area");
		area.Connect("body_entered", this, "Collided");
	}

	public override void _PhysicsProcess(float delta)
	{
		if (IsLaunched)
		{
			var forwardDir = GlobalTransform.basis.z.Normalized();

			GlobalTranslate(forwardDir * GrappleFlightSpeed * delta);
			timer += delta;
			if (timer >= GrappleFlightTime)
			{
				QueueFree();
			}
		}
	}

	public void Collided(Node body)
	{
		// Collisions only trigger after launched
		if (IsLaunched)
		{
			if (!hitSomething)
			{
				if (body.HasMethod("GrappleHit"))
				{
					body.Call("GrappleHit", GlobalTransform);
				}
			}

			hitSomething = true;
			QueueFree();
		}
	}
}
