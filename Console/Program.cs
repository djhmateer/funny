using System;
using Core.DB;

namespace ConsoleImporter {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello world");
            using (var session = new Session()){
                // Read data
                var jokes = session.Stories;
                foreach (var joke in jokes){
                    Console.WriteLine(joke.Title);
                }
            }

            Console.ReadLine();
        }
    }
}
