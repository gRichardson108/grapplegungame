using Godot;
using System;

public class Rope : Spatial
{
	[Export] public Vector3 StartPosition {get; set;} = new Vector3(0f, 0f, 0f);
	[Export] public Vector3 EndPosition {get; set;} = new Vector3(0f, 0f, 10f);

	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private ImmediateGeometry geom;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		geom = GetNode<ImmediateGeometry>("ImmediateGeometry");
		geom.AddVertex(StartPosition);
		geom.AddVertex(EndPosition);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
