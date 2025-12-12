# Espresso Brewing XR Tutorial
An interactive VR espresso-making training experience built with Unity 6.2, OpenXR, and the XR Interaction Toolkit. Designed for natural hand-tracked interaction, this application teaches users the full espresso brewing workflow—grinding beans, tamping, locking the portafilter, steaming milk, and pulling the perfect shot.

The project runs smoothly on the Meta Quest 3, and is primarily designed for hand interaction. The XR Interaction Toolkit provides hand interaction through pinching and grabbing gestures. The experience is primarily designed for right-handed users, but left-handed support can be added in future updates. Direct and ray interactions are both supported.

In the tutorial, the user is guided through each step through a UI panel near the espresso machine. The steps for brewing include
grinding beans, tamping, locking the portafilter, pulling the shot, steaming milk, and pouring a latte. The scene has ambient lofi music, which can be toggled on or off using the table button on the far left. There is also a timer button included on the table next to the UI panel for users to time their progress. Finally, a reset button is included on the far right side of the table to reset the tutorial.

---

## Features
- **Full Espresso Workflow Simulation**  
  Interact with grinder, portafilter, tamper, steam wand, and other café tools.

- **Hand-Tracked Interaction (OpenXR + XR Interaction Toolkit)**  
  Natural object pickup and responsive interactions.

- **Realistic Café Environment**  
  A detailed espresso bar setup built with assets from Sketchfab and custom models.

- **Guided Brewing Tutorial**  
  Step-by-step instructions on a UI panel, visual feedback cues, object snapping, and interactive stations.

- **Optimized for Quest 3**  
  Stable performance, smooth hand tracking, and mobile-friendly lighting.

---

## Installation & Setup

### 1. Clone the Repository
```bash
git clone <your-repo-url>
cd <your-project-folder>
```

### 2. Unity Version

This project was built with:
Unity 6000.2.2f1

### 3. Required Unity Packages

These should install automatically when the project loads:
- OpenXR Plugin
- XR Interaction Toolkit
- XR Hands (OpenXR)
- Unity Input System

### 4. Configure XR Settings
- Go to `Edit > Project Settings > XR Plug-in Management`.
- Enable `OpenXR` for the target platform (e.g., Android for Quest 3).
- In `OpenXR` settings, enable the `Hand Tracking` feature.
- Set the `Interaction Profile` to `Oculus Touch Controller Profile` for compatibility.
- In `Edit > Project Settings > Player`, under `Other Settings`, set `Active Input Handling` to `Both`.
- In `Edit > Project Settings > XR Interaction Toolkit`, enable `Enable Hand Tracking Support`.

### 5. Build Settings
- Go to `File > Build Settings`.
- Select the target platform (e.g., Android for Quest 3).
- Click `Switch Platform`.
- Add the main scene to the build.
- Click `Build and Run` to deploy to your device.

---

## Future Development Roadmap

- **Develop Workflow**
Currently, the tutorial doesn't keep track of user progress. The user can perform tasks in any order. Future updates will implement a structured workflow that guides users through the espresso-making process step-by-step, ensuring they complete each stage in the correct sequence.
- **Enhanced Hand Interactions**  
Improve hand tracking responsiveness and add more complex gestures. This could include alternative grips for different tools.
- **Additional Brewing Techniques**  
Expand the tutorial to include other coffee brewing methods like pour-over, French press, and cold brew.
- **Gamify the Experience**  
Introduce scoring, time challenges, and achievements to make learning more engaging.

---

## Project Video Demo
https://drive.google.com/file/d/1lfXmHi8CMMoljb_Vi1NEpKaDzLrXEQH3/view?usp=sharing
---

## Credits

- 3D Cup Model highpoly: https://sketchfab.com/3d-models/3d-cup-model-highpoly-17e01bc53ecd419db13e4990291935be
- Cafe-Misti: https://sketchfab.com/3d-models/cafe-misti-419c3293b0e54313be4b1f02845d606a
- Canarian Cafe - Coffee Grinder: https://sketchfab.com/3d-models/canarian-cafe-coffee-grinder-78d7e61da65c4b368074c978e742bdfc
- Canarian Cafe - Milk Jug: https://sketchfab.com/3d-models/canarian-cafe-milk-jug-344c9e052be24acfb0bc1bdca53290f9
- Coffee Packet: https://sketchfab.com/3d-models/coffee-packet-10c473aca9f1483499f52d86c3c24323
- La Marzocco: https://sketchfab.com/3d-models/la-marzocco-7bea6aeefad54c129df0be4d708a1e55
- Milk Karton: https://sketchfab.com/3d-models/milk-karton-cf379a7c1c864784b699a1b9be5ef86a
- Tamper IKAPE: https://sketchfab.com/3d-models/tamper-ikape-b1ec69eca15e4aefb4fbef5faaa5c861
- Lofi world vol 1: https://assetstore.unity.com/packages/audio/music/lofi-world-vol-1-7-free-music-tracks-214014



