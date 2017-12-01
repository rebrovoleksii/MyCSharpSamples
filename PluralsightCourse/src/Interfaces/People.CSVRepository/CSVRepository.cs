using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using People.Core;

namespace People.CSVRepository
{
    public class CSVRepository : IPeopleRepository
    {
        public IEnumerable<string> GetPeopleList()
        {
            try
            {
                var csvSource = ConfigurationManager.AppSettings["CSVRepositoryFile"];
                var people = File.ReadAllText(csvSource);
                return people.Split(',');
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
