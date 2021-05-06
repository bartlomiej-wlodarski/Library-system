using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data
{
    public static class Configuration
    {
        public static string ConnectionString => "Server=MSI\\PTTasks;Database=Library;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}