using System;
using System.Net.Http;
using System.Threading.Tasks;
using Services.ApiService;

namespace BilSimulator
{
    public class App
    {
        private readonly Car _car;
        private readonly Driver _driver;
        private readonly CarActions _carActions;
        private readonly Status _status;
        private readonly HttpClient _httpClient;
        private RandomUsers _user;

        public App()
        {
            _car = new Car();
            _driver = new Driver();
            _carActions = new CarActions();
            _status = new Status();
            _httpClient = new HttpClient();
        }

        public void Run()
        {
            var apiService = new GetTheApi(_httpClient);
            FetchAndSetApiData(apiService).Wait();

            while (true)
            {
                PrintApiData();
                _status.PrintStatus(_car, _driver);
                ShowMenu.PrintMenu();
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "1":
                        CarActions.Drive(_car, _driver);
                        break;
                    case "2":
                        CarActions.TurnLeft(_car, _driver);
                        break;
                    case "3":
                        CarActions.TurnRight(_car, _driver);
                        break;
                    case "4":
                        CarActions.Reverse(_car, _driver);
                        break;
                    case "5":
                        _carActions.Refuel(_car, _driver);
                        break;
                    case "6":
                        DriverActions.Rest(_driver);
                        break;
                    case "7":
                        Console.WriteLine("Programmet avslutas.");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt kommando. Tryck på enter för att fortsätta");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }

        private async Task FetchAndSetApiData(GetTheApi apiService)
        {
            try
            {
                _user = await apiService.FetchApiData();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching API data: {e.Message}");
            }
        }

        private void PrintApiData()
        {
            if (_user != null)
            {
                Console.WriteLine($"Welcome! {_user.Title}. {_user.First}, {_user.Last}");
            }
        }
    }
}