using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;


namespace ConsoleApp7
{
    class Guest
    {
        private object guest;

        public Guest(object guest)
        {
            this.guest = guest;
        }

        /* används inte
private readonly string _name;
private readonly string _message;
*/
        //deklarering  - används inte heller
        /*
        public Guest(string name, string message)
        {
            _name = name;
            _message = message;


        }
        */
        //hämta namn, meddelande - används ej
        /*  public string GetName()
          {
              return this._name;
          }

          public string GetMessage()
          {
              return this._message;
          } */
        internal void ToArray()
        {
            throw new NotImplementedException();
        }

        internal void RemoveAt(int v)
        {
            throw new NotImplementedException();
        }
    }
    internal static class Foo
    {
       // private static readonly object guests;
       //s private static readonly int i;
       // private static object guest;

        private static void Main()
        {
            //skriver ut meny
            Console.WriteLine("T i l d a s  g ä s t b o k");
            Console.WriteLine("1. Skriv i gästboken!");
            Console.WriteLine("2. Ta bort inlägg");
            Console.WriteLine("3. Avsluta");


            //skriva ut allt i gästboken
            try
            {
                //streamreader för läsning av fil
                using StreamReader sr = new StreamReader("guestbook.txt");
                //göra om till list
                List<string> guests = File.ReadAllLines("guestbook.txt").ToList();
                //loopa igenom inlägg
                for (var i = 0; i < guests.Count; i++)
                {
                    Console.WriteLine($"[{i}] - {guests[i]}");
                    // Console.WriteLine($"[{i}] - Name {guests[i].GetName()} Message {guests[i].GetMessage()}");
                }


            }
            //felhantering om fil ej kan läsas
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            int option = int.Parse(Console.ReadLine());

            //rensa consol
            Console.Clear();

            switch (option)
            { //om användare klickat 1 i menyval
                case 1:
                    //låt användare skriva namn
                    Console.WriteLine("Write your name.");
                    string name = Console.ReadLine();


                    if (name.Length == 0)
                    {
                        Console.WriteLine("Restart program and fill in your name correctly.");
                    }
                    else
                    {
                        
                        //låt användare skriva meddelande
                        Console.WriteLine("Write your message.");
                        string message = Console.ReadLine();



                        if (message.Length == 0)
                        {
                            Console.WriteLine("Restart program and fill in everything correctly.");
                        }
                        else
                        {
                            //spara namn i txt fil
                            File.AppendAllText("guestbook.txt", "Name: " + name);
                            //spara meddelande på fil
                            File.AppendAllText("guestbook.txt", " - Message: " + message + "\n");

                            try
                            {
                                //streamreader för att läsa i txt fil
                                using StreamReader sr = new StreamReader("guestbook.txt");
                                //gör till lista
                                List<string> guests = File.ReadAllLines("guestbook.txt").ToList();
                                //loopa igenom och sätt index på varje gästboksinlägg
                                for (var i = 0; i < guests.Count; i++)
                                {
                                    Console.WriteLine($"[{i}] - {guests[i]}");
                                }


                            }
                            //felhantering
                            catch (Exception e)
                            {
                                Console.WriteLine("The file could not be read:");
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
            

            
                  
           

                    break;

                case 2:
                    Console.WriteLine("Write number of the post that you want to delete.");


                    List<string> line = new List<string>();
                    var useroption = Console.ReadLine();
                    line = File.ReadAllLines(@"C:\Users\tilda\source\repos\ConsoleApp7\guestbook.txt").ToList();


                    line.RemoveAt(int.Parse(useroption));

                    File.WriteAllLines(@"C:\Users\tilda\source\repos\ConsoleApp7\guestbook.txt", line.ToArray());



                    break;

                case 3:
                    // Console.WriteLine("Avsluta");

                    Environment.Exit(1);
                    break;
            }


        }
    }
}





    


