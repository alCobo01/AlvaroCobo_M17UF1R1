# 🎮 Crusty Adventures

> A 2D platformer where you control the laws of physics!

## 📖 Overview

**Crusty Adventures** is a Unity-based 2D platformer game that challenges players to navigate through levels by manipulating gravity. With a mix of puzzle-solving and reflex-based gameplay, players must dodge enemies, interact with NPCs, and avoid deadly traps to reach the end.

## ✨ Key Features

### 🕹️ Core Mechanics
- **Gravity Manipulation**: Defy physics by switching gravity at will! Walk on ceilings and floors to traverse complex levels.
- **Dynamic Movement**: Smooth character movement with jumping and grounding logic.
- **Interaction System**: Engage with the world! Talk to NPCs and trigger events through a robust interaction system.

### 🤖 Enemies
- **Patrolling Enemies**: Enemies patrol designated areas, with the power to switch gravity every random seconds.

### ⚔️ Combat & Hazards
- **Object Pooling System**: Optimized performance for projectiles like bullets using a custom object pool.
- **Deadly Traps**: Watch out for cannons and instant death triggers that punish mistakes instantly.

### 🔊 Audio & Atmosphere
- **Immersive Audio**: A centralized `AudioManager` handles background music and sound effects for actions like jumping, dying, and dialogue.
- **Dialogue System**: Storytelling elements delivered through an interactive dialogue UI with typing effects.

## 🛠️ Technical Highlights

- **Input System**: Built with Unity's new Input System for responsive and modern control support.
- **Singleton Managers**: Efficient management of game levels, audio, and menus using Singleton patterns.
- **Event-Driven Architecture**: Decoupled systems using Unity Events for cleaner code (e.g., Player Death events).

## 📐 SOLID Principles Implementation

This project adheres to SOLID principles to ensure code maintainability and scalability:

- **Single Responsibility Principle (SRP)**: Classes like `Player` delegate specific logic (Movement, Gravity, Animation) to specialized behaviours (`MoveBehaviour`, `ChangeGravityBehaviour`) rather than handling everything themselves.
- **Open/Closed Principle (OCP)**: The `Character` base class allows for new character types (like `Enemy`) to be added without modifying existing code.
- **Interface Segregation Principle (ISP)**: Specific interfaces like `IInteractable` and `IAudioService` ensure that classes only implement methods they actually need.
- **Dependency Inversion Principle (DIP)**: The `Player` interacts with abstractions (`IInteractable`) rather than concrete implementations, allowing for flexible interaction with any object (NPCs, Chests, etc.).

## 🕹️ Controls

| Action | Input (Keyboard) |
| :--- | :--- |
| **Move** | `A` / `D` or `Left Stick` |
| **Switch Gravity** | `Space`|
| **Interact** | `E` |

---

*Developed by Alvaro Cobo*