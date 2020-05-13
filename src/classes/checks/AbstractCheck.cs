using System;
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

        [XmlIgnore]
        public DateTime StartTime { get; private set; }
        [XmlIgnore]
        public DateTime EndTime { get; private set; }

        protected ExecutionResult lastResult = new ExecutionResult();

        [XmlArray("eval")]
        [XmlArrayItem(typeof(FirstValueRegExEvaluation), ElementName = "first")]
        [XmlArrayItem(typeof(NumericEvaluation), ElementName = "num")]
        [XmlArrayItem(typeof(MinValuesCountEvaluation), ElementName = "min")]
        [XmlArrayItem(typeof(ExactValuesCountEvaluation), ElementName = "exactCount")]
        [XmlArrayItem(typeof(HasStringValueEvaluation), ElementName = "hasString")]
        public Evaluations Evaluations;

        protected abstract ExecutionResult internalExecute();

        public ExecutionResult Execute()
        {
            StartTime = DateTime.Now;
            try
            {
                this.lastResult = this.internalExecute();
            } catch (Exception e)
            {
                this.lastResult = new ExecutionResult(false, e.Message);
            }
            EndTime = DateTime.Now;
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

        /// <summary>
        /// V pripade Suite vrati checks "uvnitr". V pripade jednoducheho testu vrati jen ten jediny.
        /// </summary>
        /// <returns></returns>
        public abstract List<AbstractCheck> GetAllChecksToExecute();
    }
}
