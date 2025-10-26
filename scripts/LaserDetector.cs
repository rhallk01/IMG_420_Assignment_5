using Godot;
public partial class LaserDetector : Node2D
{
	[Export] public float LaserLength = 500f;
	[Export] public Color LaserColorNormal = Colors.Green;
	[Export] public Color LaserColorAlert = Colors.Red;
	[Export] public NodePath PlayerPath;

	private RayCast2D _rayCast;
	private Line2D _laserBeam;
	private Node2D _player;
	private bool _isAlarmActive = false;
	private Timer _alarmTimer;

	public override void _Ready()
	{
		SetupRaycast();
		SetupVisuals();
		// TODO: Get player reference
		// TODO: Setup alarm timer
	}

	private void SetupRaycast()
	{
		// TODO: Create and configure RayCast2D
		// TODO: Set target position
		// TODO: Set collision mask to detect player
		// Hint: _rayCast = new RayCast2D();
		
		_rayCast = new RayCast2D();
		AddChild(_rayCast);
		_rayCast.TargetPosition = new Vector2(LaserLength, 0);
		_player = GetNode<Node2D>(PlayerPath);
	}

	private void SetupVisuals()
	{
		// TODO: Create Line2D for laser visualization
		// TODO: Set width and color
		// TODO: Add points for the line
		
		_laserBeam = new Line2D();
		AddChild(_laserBeam);
		_laserBeam.Width = 3;
		_laserBeam.DefaultColor = LaserColorNormal;
	}

	public override void _PhysicsProcess(double delta)
	{
		// TODO: Force raycast update
		// TODO: Check if raycast is colliding
		// TODO: Get collision point
		// TODO: Update laser beam visualization
		// TODO: Check if hit object is player
		// TODO: Trigger alarm if player detected
		_rayCast.ForceRaycastUpdate();
		UpdateLaserBeam();
		if (_rayCast.IsColliding() && _rayCast.GetCollider() == _player)
		{
			if (!_isAlarmActive)
			{
				TriggerAlarm();
			} else if (_isAlarmActive) 
			{
				ResetAlarm();
			}
		}

	}

	private void UpdateLaserBeam()
	{
		// TODO: Update Line2D points based on raycast
		// Show full length if no collision
		// Show up to collision point if hitting something
		Vector2 endPoint = _rayCast.IsColliding() ? _rayCast.GetCollisionPoint() - GlobalPosition : _rayCast.TargetPosition;
		_laserBeam.Points = new Vector2[] { Vector2.Zero, endPoint };
	}

	private void TriggerAlarm()
	{
		// TODO: Change laser color
		// TODO: Emit signal or call alarm function
		// TODO: Add visual feedback (flashing, particles, etc.)
		// TODO: Add audio feedback (optional)
		_isAlarmActive = true;
		_laserBeam.DefaultColor = LaserColorAlert;
		GD.Print("ALARM! Player detected!");
	}

	private void ResetAlarm()
	{
		// TODO: Reset laser to normal color
		// TODO: Reset alarm state
		_isAlarmActive = false;
		_laserBeam.DefaultColor = LaserColorNormal;
	}
}
