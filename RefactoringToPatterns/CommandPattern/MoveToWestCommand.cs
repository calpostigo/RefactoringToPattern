using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveToWestCommand : IMoveCommand {
        private MarsRover marsRover;
        public MoveToWestCommand(MarsRover marsRover) {
            this.marsRover = marsRover;
        }

        public void MoveCommand() {
            marsRover.obstacleFound = ((IList)marsRover.obstacles).Contains($"{marsRover.x - 1}:{marsRover.y}");
            // check if rover reached plateau limit or found an obstacle
            marsRover.x = marsRover.x > 0 && !marsRover.obstacleFound ? marsRover.x -= 1 : marsRover.x;
        }
    }
}