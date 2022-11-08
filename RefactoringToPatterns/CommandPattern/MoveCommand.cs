using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveCommand {
        internal readonly Dictionary<char, IMoveCommand> moveCommand;
        private readonly char direction;

        public MoveCommand(MarsRover marsRover) {
            direction = marsRover.direction;
            this.moveCommand = new Dictionary<char, IMoveCommand>{
                { 'N', new MoveToNorthCommand(marsRover) },
                { 'E', new MoveToEastCommand(marsRover) },
                { 'S', new MoveToSouthCommand(marsRover) },
                { 'W', new MoveToWestCommand(marsRover) }
            };
        }

        public void Move() {
            moveCommand[direction].Execute();
        }
    }
}