Menu();

static void Menu() {
  Console.Clear();
  Console.WriteLine("What do you want to do?");
  Console.WriteLine("1 - Open file");
  Console.WriteLine("2 - New file");
  Console.WriteLine("0 - Exit");

  short option = short.Parse(Console.ReadLine()!);

  switch(option) {
    case 0: System.Environment.Exit(0); break;
    case 1: Open(); break;
    case 2: Edit(); break;
    default: Menu(); break;
  }
}

static void Open() {
  Console.WriteLine("Open file");
}

static void Edit() {
  Console.Clear();
  Console.WriteLine("Enter your text below (ESC to exit)");
  Console.WriteLine("-----------------");
  string text = "";

  do 
  {
    text += Console.ReadLine();
    text += Environment.NewLine;
  } 
  while (Console.ReadKey().Key != ConsoleKey.Escape);   

  Console.WriteLine("-----------------");
  Save(text);
}

static void Save(string text) {
  Console.Clear();
  Console.WriteLine("Which path to save the file?");
  var path = Console.ReadLine()!;

  using (var file = new StreamWriter(path)) 
  {
    file.Write(text);
  }

  Console.WriteLine($"File {path} saved successfully!");
  Console.ReadLine();
  Menu();
}