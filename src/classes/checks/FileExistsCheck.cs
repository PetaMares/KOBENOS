using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
    
namespace kobenos.classes
{
    /**
     * Zkontroluje, zda existuje specifikovany soubor.
     */
    class FileExistsCheck : SimpleCheck
    {

        private string path;

        public FileExistsCheck(string path)
        {
            this.path = path;
        }

        protected override ExecutionResult internalExecute()
        {
            bool fileExists = File.Exists(this.path);
            string message = fileExists ? "OK" : String.Format("Soubor {0} neexistuje.", this.path);
            return new ExecutionResult(fileExists, message);
        }
    }
}
