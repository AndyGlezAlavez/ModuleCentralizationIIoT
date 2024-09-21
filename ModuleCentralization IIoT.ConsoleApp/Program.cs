using Microsoft.EntityFrameworkCore;
using ModuleCentralizationIIoT.DataAccess.Contexts;

namespace ModuleCentralization_IIoT.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext appContext = new ApplicationContext("Data Source = ProgramdB.sqlite");
            if (!appContext.Database.CanConnect())
            {
                appContext.Database.Migrate();
            }


        }
    }
}
