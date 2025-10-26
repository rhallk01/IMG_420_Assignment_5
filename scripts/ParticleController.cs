using Godot;

public partial class ParticleController : GpuParticles2D
{
	private ShaderMaterial _shaderMaterial;
	
	public override void _Ready()
	{
		// TODO: Load and apply custom shader
		// TODO: Configure particle properties (Amount, Lifetime, Speed, etc.)
		// TODO: Set process material properties
		// Hint: Use a new ShaderMaterial with your custom shader
		_shaderMaterial = new ShaderMaterial();
		_shaderMaterial.Shader = GD.Load<Shader>("res://scripts/custom_particle.gdshader");
	
		ProcessMaterial = _shaderMaterial;
	
		Amount = 200;
		Lifetime = 3;
		SpeedScale = 1;
	}
	
	public override void _Process(double delta)
	{
		// TODO: Update shader parameters over time
		// Hint: Use shader parameters to create animated effects
		float time = 3;//(float)Time.GetTickMsec()/1000f;
		_shaderMaterial.SetShaderParameter("wave_intensity", 0.1f + Mathf.Sin(time) * 0.05f);
	}
}
