Physics properties you chose and why
How the raycast detection works


## Part 1: Custom Canvas Item Shader with Particles
### How the shader works:
The shader in this project makes it so that what it is applied to has a gradient that goes from orange to pink, and has a wave distortion. <br>
The gradient is created by defining the start and end colors, then setting the display color using mix(color_start, color_end, distorted_uv.y). <br>
Screenshots of the code and result for the gradient aspect of the shader are shown below under *Applies a color gradient effect*.<br>
The shader also has a wave distortion. This is done using the sin function as was shown in lecture 6, first by defining the variables wave_intensity, 
wave_amplitude, wave_frequency, and wave_speed. Then, a vertex() function is used to calculate the distortion with the equation VERTEX.x += sin(VERTEX.y * wave_frequency + TIME * wave_speed) * wave_amplitude<br>
The shader incorporates time in the equation that calculates distorion, with the TIME variable (VERTEX.x += sin(VERTEX.y * wave_frequency + **TIME** * wave_speed) * wave_amplitude) is used to make the shape of the
node that the shader is applied to shift with time.<br>
###  Requirements: Create a particle system with a custom shader that:
#### Applies a color gradient effect

Shader Code:<br>
<img width="778" height="252" alt="image" src="https://github.com/user-attachments/assets/a7a1eb7e-44ec-49b4-8dcd-292da44757a7" /><br>
<img width="585" height="91" alt="image" src="https://github.com/user-attachments/assets/6d477438-4a90-497d-a661-08625c9f4f09" /><br>
<br>Result:<br>
<img width="454" height="305" alt="image" src="https://github.com/user-attachments/assets/2a7473bd-9d61-48ba-afd5-31e1ade993f6" /><br>

#### Adds a wave distortion
Shader Code: <br>
<img width="752" height="357" alt="image" src="https://github.com/user-attachments/assets/ec32fd3e-cfb8-4019-9e6c-245089d6fd66" />
<img width="747" height="491" alt="image" src="https://github.com/user-attachments/assets/2a710778-b98d-4caf-9dc2-a7a38204fa56" />

<br>Result:<br>
![particle_with_gradient](https://github.com/user-attachments/assets/a2ef3518-3a36-4118-b5f6-be1f40432101)<br>

#### Responds to time for animation
The shader incorporates time in the equation used for calculating distortion, so that the distortion changes as time passes, causing a 'wiggle'.

Shader Code:<br>
<img width="612" height="138" alt="image" src="https://github.com/user-attachments/assets/a8d00db0-20eb-4a8e-81c9-b25b6737f5cb" />



