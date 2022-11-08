namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        public int x;
        internal int y;
        internal char direction;
        private const string availableDirections = "NESW";
        internal readonly string[] obstacles;
        internal bool obstacleFound;
        private readonly MoveCommand moveCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.obstacles = obstacles;
            moveCommand = new MoveCommand(this);
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
                    moveCommand.Move();
                }
                else if(command == 'L') {
                    // get new direction
                    var currentDirectionPosition = availableDirections.IndexOf(direction);
                    if (currentDirectionPosition == 0) {
                        direction = availableDirections[3];
                    }
                    else {
                        direction = availableDirections[currentDirectionPosition - 1];
                    }
                } else if (command == 'R') {
                    // get new direction
                    var currentDirectionPosition = availableDirections.IndexOf(direction);
                    if (currentDirectionPosition == 3) {
                        direction = availableDirections[0];
                    }
                    else {
                        direction = availableDirections[currentDirectionPosition + 1];
                    }
                }
            }
        }
    }
}