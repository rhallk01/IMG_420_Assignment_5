using Godot;
using System.Collections.Generic;
public partial class PhysicsChain : Node2D
{
	 [Export] public int ChainSegments = 5;
	 [Export] public float SegmentDistance = 30f;
	 [Export] public PackedScene SegmentScene;

	 private List<RigidBody2D> _segments = new List<RigidBody2D>();
	 private List<Joint2D> _joints = new List<Joint2D>();

	 public override void _Ready()
	 {
	 	CreateChain();
	 }

	private void CreateChain()
	{
		 // TODO: Create chain segments
		 // TODO: Position them appropriately
		 // TODO: Connect them with joints
		 // TODO: Configure joint properties (softness, bias, damping)

		 // Hints:
		 // - First segment should be StaticBody2D or pinned
		 // - Use PinJoint2D.NodeA and NodeB to connect segments
		 // - Set collision layers appropriately
	}

	// TODO: Add method to apply force to chain
	public void ApplyForceToSegment(int segmentIndex, Vector2 force)
	{
		// Apply impulse or force to specific segment
	} 
}
