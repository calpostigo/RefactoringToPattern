using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        public int x;
        internal int y;
        private char direction;
        private const string availableDirections = "NESW";
        internal readonly string[] obstacles;
        internal bool obstacleFound;
        private Dictionary<char, IMoveCommand> moveCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.obstacles = obstacles;
            moveCommand = new Dictionary<char, IMoveCommand>{
                { 'N', new MoveToNorthCommand(this) },
                { 'E', new MoveToEastCommand(this) },
                { 'S', new MoveToSouthCommand(this) },
                { 'W', new MoveToWestCommand(this) }
            };


        }
        
        public string GetState()
        {
            return !obstacleFound ? $"{x}:{y}:{direction}" : $"O:{x}:{y}:{direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M') {
                    moveCommand[direction].MoveCommand();
                }
                else if(command == 'L')
                {
                    // get new direction
                    var currentDirectionPosition = availableDirections.IndexOf(direction);
                    if (currentDirectionPosition != 0)
                    {
                        direction = availableDirections[currentDirectionPosition-1];
                    }
                    else
                    {
                        direction = availableDirections[3];
                    }
                } else if (command == 'R')
                {
                    // get new direction
                    var currentDirectionPosition = availableDirections.IndexOf(direction);
                    if (currentDirectionPosition != 3)
                    {
                        direction = availableDirections[currentDirectionPosition+1];
                    }
                    else
                    {
                        direction = availableDirections[0];
                    }
                }
            }
        }
    }
}