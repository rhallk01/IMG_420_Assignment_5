using Godot;
public partial class Player : CharacterBody2D
{
	
	[Export] public float Speed = 200f;
	[Export] public float JumpForce = 350f;
	[Export] public float Gravity = 900f;
	
	private Vector2 _velocity = Vector2.Zero;

 public override void _PhysicsProcess(double delta)
 {
	// TODO: Implement basic movement (WASD or Arrow keys)
	// TODO: Use MoveAndSlide()
	float dt = (float)delta;
	
	if (!IsOnFloor())
		_velocity.Y += Gravity * dt;
	else
		_velocity.Y = Mathf.Clamp(_velocity.Y, -JumpForce, Gravity);
			
	float inputX = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
	_velocity.X = inputX * Speed;
	
	if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		_velocity.Y = -JumpForce;	

	Velocity = _velocity;
	MoveAndSlide();
	
	for (int index = 0; index < GetSlideCollisionCount(); index++)
	{
		var collision = GetSlideCollision(index);
		if (collision.GetCollider() is RigidBody2D body)
		{
			Vector2 impulse = -collision.GetNormal() * 300f; // tweak strength
			body.ApplyImpulse(Vector2.Zero, impulse);
		}
	}

 }
}
