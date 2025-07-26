using ElevatorControl;

namespace TestElevator
{
    public class UnitTest1
    {

        [Fact]
        public void GetMessage_MovingDown_Elevator()
        {
            //Arrange
            Elevator elevator = new Elevator();

            //Act
            string status = elevator.moving(ElevatorStatus.DOWN.ToString());

            //Assert
            Assert.Equal("Moving DOWN", status);
        }

        [Fact]
        public void GetMessage_MovingUp_Elevator()
        {
            //Arrange
            Elevator elevator = new Elevator();

            //Act
            string status = elevator.moving(ElevatorStatus.UP.ToString());

            //Assert
            Assert.Equal("Moving UP", status);
        }

        [Fact]
        public void GetMessage_DoorsOpening_Elevator()
        {
            //Arrange
            Elevator elevator = new Elevator();

            //Act
            string status = elevator.doors(ElevatorStatus.OPENING.ToString());

            //Assert
            Assert.Equal("OPENING doors", status);
        }

        [Fact]
        public void GetMessage_DoorsClossing_Elevator()
        {
            //Arrange
            Elevator elevator = new Elevator();

            //Act
            string status = elevator.doors(ElevatorStatus.CLOSING.ToString());

            //Assert
            Assert.Equal("CLOSING doors", status);
        }

        [Fact]
        public void GetMessag_Arrive_Elevator()
        {
            //Arrange
            Elevator elevator = new Elevator();

            //Act
            string status = elevator.arrive();

            //Assert
            Assert.Equal("The elevator has arrived", status);
        }

        [Fact]
        public void GetMessag_Stop_Elevator()
        {
            //Arrange
            Elevator elevator = new Elevator();

            //Act
            string status = elevator.stop(ElevatorStatus.STOPPED.ToString());

            //Assert
            Assert.Equal("STOPPED", status);
        }

        [Fact]
        public void GetMessag_Goodbye_Elevator()
        {
            //Arrange
            Elevator elevator = new Elevator();

            //Act
            string status = elevator.goodbye();

            //Assert
            Assert.Equal("You have arraived. Goodbye", status);
        }

        [Fact]
        public void GetRandom_Value()
        {
            int min = 1, max = 5;
            //Arrange
            Elevator elevator = new Elevator(min:min, max:max);

            //Act
            int randomNum = elevator.randomFloor();

            //Assert
            Assert.InRange(randomNum, min, max);
        }
    }
}