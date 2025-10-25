using Godot;
public partial class Player : CharacterBody2D
{
 [Export] public float Speed = 200f;

 public override void _PhysicsProcess(double delta)
 {
	// TODO: Implement basic movement (WASD or Arrow keys)
	// TODO: Use MoveAndSlide()
	Vector2 velocity = Vector2.Zero;
		
	// Get input and move
	if (Input.IsActionPressed("ui_right")) velocity.X += 1;
	if (Input.IsActionPressed("ui_left")) velocity.X -= 1;
	if (Input.IsActionPressed("ui_down")) velocity.Y += 1;
	if (Input.IsActionPressed("ui_up")) velocity.Y -= 1;
	Velocity = velocity.Normalized() * Speed;
	MoveAndSlide();
 }
}
