# Flame Fighters

## Description
This is a firefighter truck simulator where players must put out fires, rescue citizens, and navigate city obstacles. The game is developed in Unity and includes both single-player and multiplayer modes.

## User Stories
### 1. Rescue Story
- **Description**: As a player, I want to drive the fire truck quickly to the fire location so that I can rescue people trapped and extinguish the fire. I must also be able to fill up the water tank when it finishes.
- **Tasks**:
  - Implement driving mechanics.
  - Add fires around the city.
  - Add water tanks around the city.
  - Develop fire extinguishing animations and methods.

### 2. Scoring System Story
- **Description**: As a player, I want to earn points for successfully rescuing cityzens from the fire, so that I can achieve new goals and challenges in the game. Each cityzen will sum one point.
- **Tasks**:
  - Create a scoring system corresponding the number of cityzens saved.
  - Display score on the user interface.
  - Save score for future games.

### 3. Multiplayer Game Story
- **Description**: As a player, I want to play cooperatively with friends so we can tackle bigger and more complex fires together.
- **Tasks**:
  - Develop a local multiplayer system.
  - Implement synchronization between players.

### 4. Level State (Win/Lose) Story
- **Description**: As a player, I want to receive a victory message when I put out all fires within a time limit or a defeat message if I haven't. 
- **Tasks**:
  - Create win/lose condition logic.
  - Display status notifications on screen.

### 5. Different levels Story
- **Description**: As a player, I want to be able to play different levels. The difficulty of the levels increase and to play a level,the one of before must have been won.
- **Tasks**:
  - Create different levels.
  - Save your maximum level completed for future games.
  - Implement a sequencial level logic.

## Game Requirements
- Main menu
- Different levels
- Score of each level
- AI-controlled opponents
- Animations
- Local multiplayer mode (optional)