using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace psh
{
    class Program
    {
        static void Main(string[] args)
        {
            var psCmd = "Get-Host"; // priklad psh commandu

            using (var psHost = PowerShell.Create()) // zalozit prostredi pro jeden prikaz
            {
                psHost.AddScript(psCmd); // preda "skript" prostredi

                var result = psHost.Invoke(); // zavola skript

                // result.First() kdyby byl jeden

                foreach (var pSObject in result) // projdi kazdej vysledek
                {
                    Console.WriteLine(pSObject.Properties["Version"].Value);

                    /*Console.WriteLine("-----------------");
                    // pSObject.Properties[nazevProperty].Value
                    foreach (var property in pSObject.Properties) // projdi vsechny property vracenyho objektu
                    {
                        try
                        {
                            Console.WriteLine(property.Name + " : " + property.Value); // vypis jmeno a hodnotu
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().FullName} : {ex.Message}"); // vypis chyby
                        }
                    }*/
                }
            }
        }
    }
}
