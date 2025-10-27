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
*click on image above and refresh to rerun gif*<br>
#### Responds to time for animation
The shader incorporates time in the equation used for calculating distortion, so that the distortion changes as time passes, causing a 'wiggle'.

Shader Code:<br>
<img width="612" height="138" alt="image" src="https://github.com/user-attachments/assets/a8d00db0-20eb-4a8e-81c9-b25b6737f5cb" />

## Part 2: Advanced Rigid Body Physics with Joints
### Physics properties chosen and why:
The physics properties chosen for the advanced rigid body physics with joint were mass & gravity, softness, bias, and player interaction impulse. The mass and gravity on each semgent are for natural hanging and swinging movement. 
The bias and softness on each segment, at 0.1 and 0.01 respectively, helps keep the chain links from seperating too much from one another. The player interaction impulse makes it so that when a player collides with a segment of the 
chain, a small impulse is applied to the RigidBody2D of that segment.
###  Requirements: Create a physics chain/rope system that:

#### Uses multiple RigidBody2D nodes
Code: <br>
<img width="720" height="283" alt="image" src="https://github.com/user-attachments/assets/40a425ed-342e-41b9-aaed-bef3c17e3d19" />
<br>Result:<br>
#### Connects them with PinJoint2D or DampedSpringJoint2D
Code: <br>
<img width="848" height="376" alt="image" src="https://github.com/user-attachments/assets/c1fa9e1e-cd36-4cd4-a7e7-a89f624418c8" />
#### Responds realistically to player interaction
Code (in player script):<br>
<img width="840" height="367" alt="image" src="https://github.com/user-attachments/assets/4c0bdf77-f471-43f7-9b15-23211f9e8fd3" />

<br>Result:<br>
![chain-interaction](https://github.com/user-attachments/assets/af6d2a3c-0335-46ab-ae25-cc37c7496bdf)<br>
*click on image above and refresh to rerun gif; note that the movement is slightly jerky from compression to gif*<br>
#### Has at least 5 connected segments
Code:<br>
<img width="390" height="53" alt="image" src="https://github.com/user-attachments/assets/053dd81e-5d87-4bb4-aaad-cae8e33099b0" />
<img width="720" height="283" alt="image" src="https://github.com/user-attachments/assets/40a425ed-342e-41b9-aaed-bef3c17e3d19" />

<br>Result:<br>
<img width="670" height="331" alt="image" src="https://github.com/user-attachments/assets/72bafcba-4f90-4f38-8110-f46389a755d7" />



## Part 3: Raycasting Laser with Player Detection
### How the raycast detection works
The raycast detection works by adding a raycast2D to the scene, which is represented by also adding a Line2D. <br>
In PhysicsProcess, the raycast continually checks whether or not it is colliding with anything, and if so checks if that thing is the player.<br>
If it is the player, if it is inactive, the alarm is triggered: "ALARM! Player detected!" is printed in the console and the laser goes from green to red.<br>
If it is the player and the laser is active, reset alarm is triggered: the laser goes from red to green.<br>
###  Requirements: Create a laser security system that:

#### Casts a ray continuously & Visualizes the laser beam using Line2D
Code:<br>
<img width="541" height="652" alt="image" src="https://github.com/user-attachments/assets/4394a012-18e8-4a9a-916b-2608b1929cff" />
<br>Called in Physics Process:<br>
<img width="977" height="193" alt="image" src="https://github.com/user-attachments/assets/f766e87d-e3d8-4afe-a79e-40b71c35bfbf" />

<br>Result:<br>
<img width="1081" height="410" alt="image" src="https://github.com/user-attachments/assets/923d2617-778c-457f-b9cf-06d1a7b30922" />

#### Detects when the player crosses the beam & Triggers an alarm (visual and/or audio feedback)
Code:<br>
<img width="567" height="462" alt="image" src="https://github.com/user-attachments/assets/161472a1-c3b8-4f18-9755-301a93f993ed" />
<img width="877" height="566" alt="image" src="https://github.com/user-attachments/assets/73ac743a-c7e0-4d7b-a859-5dec768ebca2" />
<br>Active to inactive:<br>
<img width="603" height="258" alt="image" src="https://github.com/user-attachments/assets/d7d1f2a1-8edd-4bfd-9ee5-8362314931d8" />

<br>Inactive to active:<br>
<img width="453" height="191" alt="image" src="https://github.com/user-attachments/assets/592ab38c-2b95-4d2f-985c-304cf7088a53" />

<br>Result:<br>
![laser-beam](https://github.com/user-attachments/assets/a14406ce-6b8f-4b9f-a62b-881cca3c0bff)<br>
*click on image above and refresh to rerun gif*<br>
<img width="802" height="562" alt="image" src="https://github.com/user-attachments/assets/cefe6b57-f4a5-40b5-8f94-e826600b6350" />
