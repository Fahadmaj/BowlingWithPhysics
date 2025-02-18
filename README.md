# Bowling with Physics

## Project Overview
This is a bowling game built in Unity that focuses on physics-based gameplay. Players can aim, launch a ball, and knock down pins while controlling the player character. The game uses Cinemachine for camera controls and implements realistic physics interactions with the bowling pins.

## Features
- **Player movement and aiming controls**: Move left and right to position the shot before launching the ball.
- **Physics-based bowling mechanics**: Uses Unity’s Rigidbody physics for realistic pin interactions.
- **Event-driven input system using `InputManager`**: Handles movement, launching, and resetting actions.
- **Score tracking system**: Keeps track of the player's total score throughout the game.
- **Reset functionality for ball and pins**: Resets the ball and pins while **keeping the score persistent**.
- **Gutter mechanic**: Detects when the ball falls into the gutter and prevents it from interfering with gameplay, also when a ball hits it, the ball travel with it to the end so it simulate a ball failling.
- **Launch Indicator**: Aligns with the camera to visually assist the player in aiming before launching the ball.
- **Invisible Walls**: Prevents the player from moving out of the bowling alley.
- **Prefabs**: Pins and other reusable objects are stored as prefabs to maintain modularity and consistency.

---

## Gameplay Demo



https://github.com/user-attachments/assets/c7331bcb-f59a-40ab-9eb5-a61d0bb57e2a



---

## Setup & Installation
### Requirements
- Unity 2021.3 LTS (or newer)
- Cinemachine package installed
- Git installed (for version control)

### How to Run
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/BowlingWithPhysics.git
   ```
2. Open the project in Unity.
3. Ensure all required packages (e.g., Cinemachine) are installed.
4. Run the game in the Unity editor.

---

## Controls
- **A / D Keys**: Move player left and right.
- **Mouse Movement**: Rotate the camera.
- **Space Key**: Launch the ball.
- **R Key**: Reset the game (pins and ball reset, but score remains persistent).

---

## Notes
- The **score remains persistent** across resets, allowing players to continue scoring throughout multiple rounds.
- All known bugs have been fixed, ensuring smooth gameplay and proper physics interactions.

Enjoy playing **Bowling with Physics!** :D

