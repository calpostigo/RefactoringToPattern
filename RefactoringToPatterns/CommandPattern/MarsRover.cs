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
        private readonly MoveToNorthCommand moveToNorthCommand;
        private readonly MoveToWestCommand moveToWestCommand;
        private readonly MoveToSouthCommand moveToSouthCommand;
        private readonly MoveToEastCommand moveToEastCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.obstacles = obstacles;
            moveToNorthCommand = new MoveToNorthCommand(this);
            moveToWestCommand = new MoveToWestCommand(this);
            moveToSouthCommand = new MoveToSouthCommand(this);
            moveToEastCommand = new MoveToEastCommand(this);
        }
        
        public string GetState()
        {
            return !obstacleFound ? $"{x}:{y}:{direction}" : $"O:{x}:{y}:{direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    switch (direction)
                    {
                        case 'E':
                            moveToEastCommand.MoveToEast();
                            break;
                        case 'S':
                            moveToSouthCommand.MoveToSouth();
                            break;
                        case 'W':
                            moveToWestCommand.MoveToWest();
                            break;
                        case 'N':
                            moveToNorthCommand.MoveToNorth();
                            break;
                    }
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