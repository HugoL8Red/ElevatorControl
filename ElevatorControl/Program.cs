namespace ElevatorControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hugo elevator!!");
            Console.Write("Enter which floor you are: ");

            Elevator elevator = new Elevator(min: 1, max: 5);
            int result = 0;
            string floor = Console.ReadLine();
            elevator.validFloor = Number.validNumber(floor, out result);

            while (elevator.validFloor == false)
            {
                elevator.validFloor = false;
                Console.WriteLine("Please enter a number between 1 and 5");
                floor = Console.ReadLine();
                elevator.validFloor = Number.validNumber(floor, out result);
            };

            elevator.currentFloor = result;

            while (true)
            {
                if (elevator.Exit)
                {
                    break; // Exit the loop
                }

                //Create elevator object
                floor = elevator.NewFloor == 0 ? floor : elevator.NewFloor.ToString();

                //Switch for floors
                switch (floor)
                {
                    case "1":
                        elevator.floor(ElevatorStatus.DOWN);
                        break;
                    case "2":
                    case "3":
                    case "4":
                        elevator.floor(ElevatorStatus.NOTHING);
                        break;
                    case "5":
                        elevator.floor(ElevatorStatus.UP);
                        break;
                    default:
                        Console.WriteLine("Invalid floor. Please enter a number between 1 and 5.");
                        break;
                }
            }

            Console.ReadKey();
        }

    }
}