using kobenos.classes.configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.classes.test
{
    /**
     * Reprezentuje jednu konkretni kontrolu nastaveni systemu.
     */
    abstract class Check
    {
        public CheckConfiguration config;

        public Check(CheckConfiguration config)
        {
            this.config = config;
        }

    }
}
