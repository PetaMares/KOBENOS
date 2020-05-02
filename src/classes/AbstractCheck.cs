﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace kobenos.classes
{
    /*
     * Abstraktni spustitelna kontrola. Sada kontrol (Suite) i jednotlive kontroly (WmiCheck atd.) jsou odvozene od teto tridy.
     */
    public abstract class AbstractCheck
    {
        
        private string name;

        protected ExecutionResult lastResult = new ExecutionResult();

        protected abstract ExecutionResult internalExecute();

        public ExecutionResult execute()
        {
            this.lastResult = this.internalExecute();
            return this.lastResult;
        }

        public ExecutionResult Result
        {
            get
            {
                return lastResult;
            }
        }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get => name; set => name = value; }
    }
}