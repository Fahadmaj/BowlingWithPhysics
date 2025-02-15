# Bowling with Physics

## Project Overview
This is a bowling game built in Unity that focuses on physics-based gameplay. Players can aim, launch a ball, and knock down pins while controlling the player character. The game uses Cinemachine for camera controls and implements realistic physics interactions with the bowling pins.

## Features
- Player movement and aiming controls
- Physics-based bowling mechanics
- Event-driven input system using `InputManager`
- Score tracking system
- Reset functionality for ball and pins

---

## Known Bugs & Issues
### Pins Don't Reset Properly
- Issue: After pressing reset, only one pin resets, while others stay in their fallen position.
- Possible Fix: Double-check if all pins are stored correctly in `StoreInitialPinState()` and that `ResetPins()` iterates through all children.

### Launch Indicator Won't Attach to FreeLook Camera
- Issue: The Launch Indicator does not properly align with the Cinemachine FreeLook Camera.
- Possible Fix:
  - Ensure that `freeLookCamera` is assigned in `LaunchIndicator.cs`
  - Verify that the indicator updates in `Update()` with `freeLookCamera.transform.forward`.

---

## Gameplay Demo



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
