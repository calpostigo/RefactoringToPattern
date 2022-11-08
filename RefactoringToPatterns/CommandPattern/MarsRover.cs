namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        public int x;
        internal int y;
        internal char direction;
        internal const string availableDirections = "NESW";
        internal readonly string[] obstacles;
        internal bool obstacleFound;
        private readonly MoveCommand moveCommand;
        private readonly TurnRightCommand turnRightCommand;
        private readonly TurnLeftCommand turnLeftCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.obstacles = obstacles;
            moveCommand = new MoveCommand(this);
            turnRightCommand = new TurnRightCommand(this);
            turnLeftCommand = new TurnLeftCommand(this);
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
                    turnLeftCommand.TurnLeft();
                } else if (command == 'R') {
                    turnRightCommand.TurnRight();
                }
            }
        }
    }
}