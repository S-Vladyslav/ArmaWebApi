using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class CustomConfigurationManager : ICustomConfigurationManager
    {
        private readonly ConfigurationManager configuration;

        public CustomConfigurationManager(ConfigurationManager configuration)
        {
            this.configuration = configuration;
        }

        public string Test => configuration.GetConnectionString("Test");

        public string DBConnectionString => configuration.GetConnectionString("DBConnectionString");

    }
}
