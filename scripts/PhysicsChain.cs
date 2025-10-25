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
	// TODO: Create chain segments
	// TODO: Position them appropriately
	// TODO: Connect them with joints
	// TODO: Configure joint properties (softness, bias, damping)

	// Hints:
	// - First segment should be StaticBody2D or pinned
	// - Use PinJoint2D.NodeA and NodeB to connect segments
	// - Set collision layers appropriately
	private void CreateChain()
	{
		Node2D previous = null;
		
		for (int i = 0; i < CHainSegments; i++)
		{
			var segment = (RigidBody2D)SegmentScene.Instantiate();
			AddChild(segment);
			segment.Position = new Vector2(i * SegmentDistance, 0);
			_segment.Add(segment);
			
			if(previous != null)
			{
				var joint = PinJoint2D
				{
					NodeA = previous.GetPath(), 
					NodeB = segment.GetPath()
				};
				AddChild(joint);
				_joints.Add(joint);
			}
			previous = segment;
		}
		_segments[0].Freeze = true;
	}

	// TODO: Add method to apply force to chain
	public void ApplyForceToSegment(int segmentIndex, Vector2 force)
	{
		// Apply impulse or force to specific segment
		if (segmentIndex >= 0 && index < _segments.Count)
		{
			_segments[index].ApplyImpulse(Vector2.Zero, force);
		}
	} 
}
