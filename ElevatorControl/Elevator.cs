using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControl
{
    public class Elevator
    {
        public int currentFloor { get; set; }
        public int floorSelected { get; set; }
        public int timeElevator { get; set; } = 0;
        public int NewFloor { get; set; } = 0;
        public int min { get; set; } = 0;
        public int max { get; set; } = 0;
        public bool Exit { get; set; } = false;

        public Elevator(int currentFloor = 0, int min = 0, int max = 0) 
        {
            this.currentFloor = currentFloor;
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int randomFloor()
        {
            Random random = new Random();
            int randomNumber = random.Next(min, max);
            return randomNumber;
        }

        /// <summary>
        /// Validate current user floor and elevator floor
        /// </summary>
        /// <param name="move">Moving to DOWN or UP</param>
        public void floor(ElevatorStatus move)
        {
            //get floor, if there is not any floor selected, assign a new ranfom
            NewFloor = NewFloor == 0 ? randomFloor() : NewFloor;            

            Console.WriteLine($"The elevator is in {NewFloor} floor");

            if (NewFloor == currentFloor)
            {
                Console.WriteLine(doors(ElevatorStatus.OPENING.ToString()));
            }
            else if (move == ElevatorStatus.UP || move == ElevatorStatus.DOWN)
            {
                Console.WriteLine(moving(move.ToString()));

                printFloors(NewFloor, currentFloor, move);

                Console.WriteLine(stop(ElevatorStatus.STOPPED.ToString()));
                Console.WriteLine(arrive());
                Console.WriteLine(doors(ElevatorStatus.OPENING.ToString()));
            }
            else if (floorSelected != NewFloor)
            {
                Console.WriteLine($"Select a button (1.-{ElevatorStatus.DOWN.ToString()}/2.- {ElevatorStatus.UP.ToString()})");
                var button = Console.ReadLine();
                var getmove = NewFloor < currentFloor ? ElevatorStatus.UP : ElevatorStatus.DOWN;

                Console.WriteLine(moving(getmove.ToString()));

                Console.WriteLine("Elevator arraving\n");
                printFloors(NewFloor, currentFloor, getmove);

                NewFloor = currentFloor;

                Console.WriteLine("Please select a floor: ");

                Console.WriteLine("1");
                Console.WriteLine("2");
                Console.WriteLine("3");
                Console.WriteLine("4");
                Console.WriteLine("5\n");

                floorSelected = Convert.ToInt32(Console.ReadLine());

                printFloors(NewFloor, currentFloor, move);
                Console.WriteLine(stop(ElevatorStatus.STOPPED.ToString()));
                Console.WriteLine(arrive());
                Console.WriteLine(doors(ElevatorStatus.OPENING.ToString()));
            }                        
            
            selectFloor();

            Console.WriteLine("Do you want to move to another floor?\n Please press '1' to continue or press '0' to exit");
            var result = Console.ReadLine();
            if (result == "0")
            {
                Exit = true;
            }

        }

        /// <summary>
        /// Moving message
        /// </summary>
        /// <param name="move">Moving to DOWN or UP</param>
        /// <returns>Message</returns>
        public string moving(string move)
        {
            return $"Moving {move}";
        }

        /// <summary>
        /// Open doors message
        /// </summary>
        /// <param name="move">Moving door, open or close</param>
        /// <returns>Message</returns>
        public string doors(string move)
        {
           return $"{move} doors";
        }

        /// <summary>
        /// Godbay message
        /// </summary>
        /// <returns>Godbay message</returns>
        public string goodbye()
        {
            return "You have arraived. Goodbye";
        }

        /// <summary>
        /// Logic for floor selected
        /// </summary>
        private void selectFloor()
        {
            bool toContinue = false;
            timeElevator = 0;

            //Sjow floors
            Console.WriteLine("Please select a floor: ");
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");
            Console.WriteLine("5\n");

            floorSelected = Convert.ToInt32(Console.ReadLine());

            //Validate if the button pressed is the same floor that the user is
            while (!toContinue)
            {
                if (floorSelected == 0 || floorSelected > 5)
                {
                    Console.WriteLine("Invalid floor. Please enter a number between 1 and 5.");
                }
                else if (floorSelected == currentFloor)
                {
                    Console.WriteLine("You have selected the floor that you are right now");
                    Console.WriteLine("Please select a floor: ");
                    floorSelected = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    toContinue = true;
                }
            }

            Console.WriteLine($"Floor {floorSelected} selected\n");
            Console.WriteLine(doors(ElevatorStatus.CLOSING.ToString()));

            if (currentFloor > floorSelected)
            {
                Console.WriteLine(moving(ElevatorStatus.DOWN.ToString()));
                timeElevator = currentFloor - floorSelected + 1;
                printFloors(currentFloor, floorSelected, ElevatorStatus.DOWN);
            }
            else
            {
                Console.WriteLine(moving(ElevatorStatus.UP.ToString()));
                timeElevator = floorSelected - currentFloor + 1;
                printFloors(currentFloor, floorSelected,  ElevatorStatus.UP);
            }

            Thread.Sleep(timeElevator * 1000);

            Console.WriteLine(stop(ElevatorStatus.STOPPED.ToString()));
            Console.WriteLine(goodbye());
            Console.WriteLine(doors(ElevatorStatus.OPENING.ToString()));

            NewFloor = floorSelected;
            currentFloor = floorSelected;
        }

        /// <summary>
        /// Stop message
        /// </summary>
        /// <param name="stop">stop message</param>
        /// <returns>stop message</returns>
        public string stop(string stop)
        {
            return stop;
        }

        /// <summary>
        /// Arrive message
        /// </summary>
        /// <returns>Arrive message</returns>
        public string arrive()
        {
            return "The elevator has arrived";
        }

        /// <summary>
        /// Print cicle for floors
        /// </summary>
        /// <param name="startFloor">start cicle</param>
        /// <param name="endFloor">end cicle</param>
        /// <param name="status">status elevator</param>
        private void printFloors(int startFloor, int endFloor, ElevatorStatus status)
        {
            if (status == ElevatorStatus.DOWN)
            {
                for (int i = startFloor; i >= endFloor; i--)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Floor: {i}");
                }
            }
            else
            {
                for (int i = startFloor; i <= endFloor; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Floor: {i}");
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ElevatorStatus
    {
        [Description("UP")]
        UP = 1,

        [Description("STOPPED")]
        STOPPED = 2,

        [Description("DOWN")]
        DOWN = 3,

        [Description("NOTHING")]
        NOTHING = 4,

        [Description("CLOSING")]
        CLOSING = 5,

        [Description("OPENING")]
        OPENING = 6
    }
}
