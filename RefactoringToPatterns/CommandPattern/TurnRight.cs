namespace RefactoringToPatterns.CommandPattern {
    public class TurnRightCommand {
        private readonly MarsRover marsRover;
        public TurnRightCommand(MarsRover marsRover) {
            this.marsRover = marsRover;
        }

        internal void TurnRight() {
            // get new direction
            var currentDirectionPosition = MarsRover.availableDirections.IndexOf(marsRover.direction);
            if (currentDirectionPosition == 3) {
                marsRover.direction = MarsRover.availableDirections[0];
            }
            else {
                marsRover.direction = MarsRover.availableDirections[currentDirectionPosition + 1];
            }
        }
    }
}