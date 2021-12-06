namespace TexturePig.Build
{
    internal class Program
    {
        readonly static string BaseDirectory = Directory.GetCurrentDirectory().Replace("\\", "/").Replace("src/TexturePig.Build/bin/Debug/net6.0", string.Empty);
        readonly static string BaseExeptionDirectory = BaseDirectory + "/import-server";
        static void Main(string[] args) 
        {
            Console.Write(new FigletText("TexturePig").LeftAligned());
            Console.Status()
            .Start("Thinking...", ctx =>
            {
                ctx.Spinner(Spinner.Known.Aesthetic);
                ctx.Status("Importing bulk files.");
                try
                {
                    Console.MarkupLine($"Imported input directory: {BaseExeptionDirectory}");
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                Thread.Sleep(1000);
                string[] BaseExeptionDirectories = Directory.GetDirectories(BaseExeptionDirectory);
                foreach (var dir in BaseExeptionDirectories)
                {
                    Console.MarkupLine($"-> [green]{dir.Replace("\\", "/").Replace("//", "/").Replace(BaseExeptionDirectory + "/", string.Empty)}[/]");
                }
                Thread.Sleep(2000);
                ctx.Status("Press [red]{ENTER}[/] to continue.");
                System.Console.ReadKey();
            });
        }
    }
}