using System.ComponentModel.Design;

namespace CIS_195_Lesson_4_Private_Multiple_Objects
{
    class Aircraft
    {
        private string _manufacturer;
        private string _engineType;
        private int _engineCount;
        private string _gearType;

        public Aircraft()
        {
            _engineCount = 0;
            _engineType = string.Empty;
            _gearType = string.Empty;
            _manufacturer = string.Empty;
        }

        public Aircraft(string mfg, string engineType, int engineCount, string gearType)
        {
            _manufacturer = mfg;
            _engineCount = engineCount;
            _gearType = gearType;
            _engineType = engineType;
        }

        public void setMfg(string mfg) { _manufacturer = mfg; }
        public string getMfg() { return _manufacturer; }
        public void setEngineCount(int engineCount) { _engineCount = engineCount; }
        public int getEngineCount() { return _engineCount; }
        public void setEngineType(string engineType) { _engineType = engineType; }
        public string getEngineType() { return _engineType; }
        public void setGearType(string gearType) { _gearType = gearType; }
        public string getGearType() { return _gearType; }

        public virtual void addChange()
        {
            Console.Write("Manufacturer =");
            setMfg(Console.ReadLine());
            Console.Write("Engine count =");
            setEngineCount(int.Parse(Console.ReadLine()));
            Console.Write("Engine Type =");
            setEngineType(Console.ReadLine());
            Console.Write("Gear Type =");
            setGearType((Console.ReadLine()));
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"Manufacturer: {getMfg()}");
            Console.WriteLine($" Engine Type: {getEngineType()}");
            Console.WriteLine($"Engine Count: {getEngineCount()}");
            Console.WriteLine($"Landing Gear: {getGearType()}");
        }
    }
    class PassengerJet : Aircraft
    {
        private int _seatCount;
        private int _range;
        private string _airline;

        public PassengerJet()
            : base()
        {
            _seatCount = 0;
            _range = 0;
            _airline = string.Empty;
        }

        public PassengerJet(string mfg, string engineType, int engineCount, string gearType, int seatCount, int range, string airline)
            : base(mfg, engineType, engineCount, gearType)
        {
            _seatCount = seatCount;
            _range = range;
            _airline = airline;
        }
        public void SetSeatCount(int seatCount) { _seatCount = seatCount; }
        public int GetSeatCount() { return _seatCount; }
        public void SetRange(int range) { _range = range; }
        public int GetRange() { return _range; }
        public void SetAirline(string airline) { _airline = airline; }
        public string GetAirline() { return _airline; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Seat count: ");
            SetSeatCount(int.Parse(Console.ReadLine()));
            Console.Write("Range: ");
            SetRange(int.Parse(Console.ReadLine()));
            Console.Write("Airline name: ");
            SetAirline(Console.ReadLine());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"  Seat count: {GetSeatCount()}");
            Console.WriteLine($"       Range: {GetRange()}");
            Console.WriteLine($"     Airline: {GetAirline()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int daPlanes;
            Console.WriteLine("How many light aircraft will you be entering?");
            while (!int.TryParse(Console.ReadLine(), out daPlanes))
                Console.WriteLine("Try again, smart guy.");
            Aircraft[] planes = new Aircraft[daPlanes];

            int daHeavies;
            Console.WriteLine("How many passenger jets will you be entering?");
            while (!int.TryParse(Console.ReadLine(), out daHeavies))
                Console.WriteLine("Try again, my friend.");
            PassengerJet[] heavies = new PassengerJet[daHeavies];

            int choice, rec, type;
            int numPlanes = 0, numHeavies = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for passenger jet, 2 for light aircraft.");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for big plane, 2 for small plane.");

                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (numHeavies <= daHeavies)
                                {
                                    heavies[numHeavies] = new PassengerJet();
                                    heavies[numHeavies].addChange();
                                    numHeavies++;
                                }
                                else
                                    Console.WriteLine("you have added all the jets you said you would enter.");
                            }
                            else
                            {
                                if (numPlanes <= daPlanes)
                                {
                                    planes[numPlanes] = new Aircraft();
                                    planes[numPlanes].addChange();
                                    numPlanes++;
                                }
                                else
                                    Console.WriteLine("you have added all the light craft you said you would add.");
                            }
                            break;
                        case 2:
                            Console.Write("Enter which one you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter which one you want to change: ");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > numHeavies - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                heavies[rec].addChange();
                            }
                            else
                            {
                                while (rec > numPlanes - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the number you want to change: ");
                                    rec--;
                                }
                                planes[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < numHeavies; i++)
                                    heavies[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < numPlanes; i++)
                                    planes[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }
        private static int Menu()
        {
            Console.WriteLine("Make a selection: ");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}
