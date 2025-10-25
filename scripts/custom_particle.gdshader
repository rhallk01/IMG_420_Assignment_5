shader_type canvas_item;
// TODO: Add uniform variables for:
// - Time-based animation
// - Color gradient (hint: use multiple color uniforms)
// - Wave intensity
uniform float wave_intensity = 0.1;
uniform vec4 color_start : source_color = vec4(1.0, 0.5, 0.0, 1.0);
uniform vec4 color_end : source_color = vec4(1.0, 0.0, 0.5, 1.0);

uniform float wave_amplitude : hint_range(0.0, 50.0) = 10.0;
uniform float wave_frequency : hint_range(0.0, 20.0) = 5.0;
uniform float wave_speed : hint_range(0.0, 10.0) = 2.0;

void vertex() {
// Create wave effect on vertices
VERTEX.x += sin(VERTEX.y * wave_frequency + TIME * wave_speed)
* wave_amplitude;
}

void fragment() {
// TODO: Implement wave distortion using UV and TIME
// TODO: Create color gradient based on UV.y
// TODO: Apply final color with alpha
// Starter hint:
// vec2 uv = UV;
// uv.x += sin(uv.y * 10.0 + TIME) * wave_intensity;
// Sample texture with modified UVs
vec2 distorted_uv = UV;
distorted_uv.x += sin(UV.y * wave_frequency * 10.0 + TIME * wave_speed)
* wave_intensity;
vec4 color = mix(color_start, color_end, distorted_uv.y);
COLOR = color;
}