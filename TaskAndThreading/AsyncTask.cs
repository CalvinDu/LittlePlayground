using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAndThreading
{
    public static class AsyncTask
    {
        public static void Go()
        {
            var test = new Task1();
            test.GoAsync();
            Console.WriteLine($"This is Go!");
        }
    }

    public class Task1
    {
        private readonly HttpClient _httpClient;

        public Task1()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:60985/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async void GoAsync()
        {
            var task1 = DoWebApiTask("task1");
            var task2 = Task.Run(() => DoTask1("task2"));
            await task1;
            await task2;
        }

        public Task DoTask1(string name)
        {
            Console.WriteLine($"{name} is running");
            Task.Delay(5000).Wait();
            Console.WriteLine($"{name} completed running");
            return Task.FromResult(0);
        }

        public Task DoTask2(string name)
        {
            Console.WriteLine($"{name} is running");
            Thread.Sleep(5000);
            Console.WriteLine($"{name} completed running");
            return Task.FromResult(0);
        }

        public void DoTask3(string name)
        {
            Console.WriteLine($"{name} is running");
            Thread.Sleep(5000);
            Console.WriteLine($"{name} completed running");
        }

        public async Task DoWebApiTask(string name)
        {
            Console.WriteLine($"{name} is running");
            var result = await _httpClient.GetAsync("api/values/5");
            Console.WriteLine($"{name} completed running with {result}");
        }
    }

}
