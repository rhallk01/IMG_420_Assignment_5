using Godot;
public partial class Player : CharacterBody2D
{
 [Export] public float Speed = 200f;

 public override void _PhysicsProcess(double delta)
 {
 // TODO: Implement basic movement (WASD or Arrow keys)
 // TODO: Use MoveAndSlide()

 Vector2 velocity = Velocity;

 // Get input and move

 Velocity = velocity;
 MoveAndSlide();
 }
}
