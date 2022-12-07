// enter http://localhost:5654/ in browser to test it out 

using ConsoleApi;

var apiService = new ApiService(5654);

await apiService.Start();

Console.ReadKey();

await apiService.Stop();