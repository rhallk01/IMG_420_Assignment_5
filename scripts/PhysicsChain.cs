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
		if (SegmentScene == null)
		{
			GD.PushError("SegmentScene is not assigned in the Inspector!");
			return;
		}
		
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
		
		for (int i = 0; i < ChainSegments; i++)
		{
			var _segment = (RigidBody2D)SegmentScene.Instantiate();
			AddChild(_segment);
			_segment.Position = new Vector2(i * SegmentDistance, 0);
			_segment.AddChild(_segment);
			
			if(previous != null)
			{
				var joint = new PinJoint2D
				{
					NodeA = previous.GetPath(),
					NodeB = _segment.GetPath()
				};

				AddChild(joint);
				_joints.Add(joint);
			}
			previous = _segment;
		}
		_segments[0].Freeze = true;
	}

	// TODO: Add method to apply force to chain
	public void ApplyForceToSegment(int segmentIndex, Vector2 force)
	{
		// Apply impulse or force to specific segment
		if (segmentIndex >= 0 && segmentIndex < _segments.Count)
		{
			_segments[segmentIndex].ApplyImpulse(Vector2.Zero, force);
		}
	} 
}
