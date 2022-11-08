using System.Linq;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveToNorthCommand {
        private MarsRover marsRover;
        public MoveToNorthCommand(MarsRover marsRover) {
            this.marsRover = marsRover;
        }

        internal void MoveCommand() {
            marsRover.obstacleFound = marsRover.obstacles.Contains($"{marsRover.x}:{marsRover.y - 1}");
            // check if rover reached plateau limit or found an obstacle
            marsRover.y = marsRover.y > 0 && !marsRover.obstacleFound ? marsRover.y -= 1 : marsRover.y;
        }
    }
}