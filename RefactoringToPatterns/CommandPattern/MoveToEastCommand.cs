using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveToEastCommand : IMoveCommand {
        private MarsRover marsRover;
        public MoveToEastCommand(MarsRover marsRover) {
            this.marsRover = marsRover;
        }

        public void MoveCommand() {
            marsRover.obstacleFound = ((IList)marsRover.obstacles).Contains($"{marsRover.x + 1}:{marsRover.y}");
            // check if rover reached plateau limit or found an obstacle
            marsRover.x = marsRover.x < 9 && !marsRover.obstacleFound ? marsRover.x += 1 : marsRover.x;
        }
    }
}