namespace ElevatorControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hugo elevator!!");
            Console.Write("Enter which floor you are: ");

            string floor = Console.ReadLine();
            Elevator elevator = new Elevator(Convert.ToInt32(floor), 1, 5);

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