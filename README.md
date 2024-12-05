# BattleshipGame
A recreation of the classic Battleship game in C#, starting with a terminal-based interface and potentially expanding to a graphical interface with custom-designed assets.

## Table of Contents

- [About the Project](#about-the-project)
- [Gameplay](#gameplay)
- [Roadmap](#roadmap)
  - [Version 1 (V1)](#version-1-v1)
  - [Version 2 (V2)](#version-2-v2)
  - [Version 3 (V3)](#version-3-v3)
  - [Future Plans](#future-plans)

## About the Project
BattleshipGame is a C# implementation of the classic Battleship game. The project aims to:

- Develop a console-based version of Battleship where the player competes against the computer.
- Enhance the computer's intelligence over multiple versions to improve gameplay difficulty and realism.
- Eventually create a graphical user interface (GUI) with custom-designed assets for an interactive experience.

## Gameplay
- **Grid:** A fixed-size grid where both the player and the computer place their ships.
- **Ships:**
  - Three ships of different sizes: 1, 2, and 3 grid spaces.
  - Ships are randomly placed on the grid for both the player and the computer.
- **Objective:** Be the first to sink all of the opponent's ships.
- **Turns:**
  - Players take turns guessing the location of the opponent's ships by selecting grid coordinates.
  - Feedback is provided after each guess (hit or miss).

## Roadmap
## Version 1 (V1)
- **Features:**
  - Basic gameplay with random ship placement.
  - The computer makes random guesses for the player's ship locations.
- **Goal:** Establish the core mechanics of the game in a terminal environment.
## Version 2 (V2)
- **Features:**
  - Improved Computer Intelligence: The computer makes educated guesses after a hit.
  - If the computer hits a ship at a coordinate (e.g., A3), it will next guess adjacent cells (e.g., A4), assuming the ship may occupy multiple spaces.
  - Enhanced user experience with additional feedback and messages.
- **Goal:** Increase the difficulty and realism of the computer opponent.
## Version 3 (V3)
- **Features:**
  - Advanced Computer Strategy: The computer analyzes previous guesses and possible ship placements.
  - Implements tactics to optimize its guesses based on remaining ship sizes and possible orientations.
  - Bug fixes and performance improvements.
- **Goal:** Provide a challenging experience that requires strategic thinking from the player.

## Future Plans
**Graphical User Interface (GUI):**
- Develop a frontend with custom-designed assets.
- Enable players to interact with the game visually rather than through the terminal.

**Multiplayer Support:**
- Allow players to compete against each other locally or over a network.

**Additional Features:**
- Customizable settings (grid size, number of ships).
- Sound effects and animations.
