using Godot;
using System;

public class Bullet : Spatial
{
	[Export] public float BulletSpeed { get; set; } = 70.0f;

	// Collision area
	private Area area;

	// flag for eliminating double-collisions when moving at high speed
	private bool hitSomething = false;

	// amount of time before bullet disappears
	[Export] public float BulletAliveTime { get; set; } = 600.0f;
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
		var forwardDir = GlobalTransform.basis.z.Normalized();
		GlobalTranslate(-forwardDir * BulletSpeed * delta);
		timer += delta;
		if (timer >= BulletAliveTime)
		{
			QueueFree();
		}
	}

	public void Collided(Node body)
	{
		if (!hitSomething)
		{
			if (body.HasMethod("BulletHit"))
			{
				body.Call("BulletHit", GlobalTransform);
			}
		}

		hitSomething = true;
		QueueFree();
	}
}
