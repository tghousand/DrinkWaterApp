namespace DrinkWaterApp
{
    internal static class Program
    {
        /// By Tyler Housand
        /// 12/15/2022
        /// A simple program to set a timer to remind you to drink water. The timer can be repeated.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}