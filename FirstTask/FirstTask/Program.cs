using System;

using FirstTask;

Startup<char> startup = new Startup<char>(args, '*', ' ');
startup.Start();

Console.ReadKey();