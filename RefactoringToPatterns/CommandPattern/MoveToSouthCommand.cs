using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveToSouthCommand {
        private MarsRover marsRover;
        public MoveToSouthCommand(MarsRover marsRover) {
            this.marsRover = marsRover;
        }

        internal void MoveCommand() {
            marsRover.obstacleFound = ((IList)marsRover.obstacles).Contains($"{marsRover.x}:{marsRover.y + 1}");
            // check if rover reached plateau limit or found an obstacle
            marsRover.y = marsRover.y < 9 && !marsRover.obstacleFound ? marsRover.y += 1 : marsRover.y;
        }
    }
}