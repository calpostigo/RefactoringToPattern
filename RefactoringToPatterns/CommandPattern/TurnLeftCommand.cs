namespace RefactoringToPatterns.CommandPattern {
    public class TurnLeftCommand {
        private MarsRover marsRover;
        public TurnLeftCommand(MarsRover marsRover) {
            this.marsRover = marsRover;
        }

        internal void TurnLeft() {
            // get new direction
            var currentDirectionPosition = MarsRover.availableDirections.IndexOf(marsRover.direction);
            if (currentDirectionPosition == 0) {
                marsRover.direction = MarsRover.availableDirections[3];
            }
            else {
                marsRover.direction = MarsRover.availableDirections[currentDirectionPosition - 1];
            }
        }
    }
}