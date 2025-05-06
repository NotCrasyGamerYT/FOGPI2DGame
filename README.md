# FOGPI2DGame
Description

This Unity project is a two-player 2D fighting game featuring:

Character movement (walk, jump, flip)

Attack mechanics with hit detection

Health system and win/round logic

Character selection screen

Round-based match flow

Features

Movement: Walk left/right, jump when grounded

Attack: Press Attack button to damage opponents

Health System: Players have HP bars; death triggers round end

Rounds & Match: Best-of-N rounds; auto-reset between rounds

Character Selection: UI to choose fighters before match

Gizmos: Visual debug spheres for ground check & attack range

Requirements

Unity 2021.3 LTS or newer

New Input System package installed

A modern gamepad (optional)

Setup & Installation

Clone or unzip the project into your Unity workspace.

Open the project in Unity.

Install and enable the Input System (Edit → Project Settings → Input System).

Ensure PlayerControls.inputactions is in place and regenerated.

Add your character ScriptableObject assets (in Assets/Scripts/CharacterData.cs).

Controls

Player

Move

Jump

Attack

P1

A / D (or joystick)

Space (or buttonSouth)

G (or Attack action)

P2

← / → (or joystick)

UpArrow (or buttonSouth)

P (or Attack action)

Scripts Overview

MovementP1.cs & MovementP2.cs

Binds to Move, Jump, and Attack actions.

Uses a groundCheck Transform and groundLayer mask for jumping.

Flips sprite based on move direction.

Draws Gizmos for ground-check and attack radius.

P1Health.cs & P2Health.cs

Tracks health, maxHealth, and currentHealth.

Updates UI health bar (Image.fillAmount).

Triggers damage and death animations.

Disables movement on death.

RoundManager.cs

Manages per-round logic: start, end, reset.

Tracks p1Score, p2Score and roundsToWin.

Resets players (health, position, movement) between rounds.

Fires match finish when someone reaches roundsToWin.

CharacterSelectManager.cs & CharacterSelectUI.cs

Populates UI with character portrait buttons.

Records P1Selection and P2Selection via ScriptableObjects.

Loads FightScene and spawns chosen prefabs at spawn points.

How to Play

Launch the CharacterSelect scene. Choose fighters for both players and press Start Fight.

In the FightScene, use your assigned controls to move, jump, and attack.

Reduce your opponent’s health to zero to win the round.

First to N round wins the match.

Contributing

Feel free to:

Adjust moveSpeed, jumpForce, radius, and UI layouts.

Add new characters by creating more CharacterData assets.

Enhance animations, effects, and sound.

License

This project is licensed under the MIT License. See [LICENSE.md] for details.

