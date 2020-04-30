using kobenos.category.test;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace kobenos.category
{
    class Category : ICategory
    {
        public ObservableCollection<AbstractTest> tests { get; set; }
        public string name { get; set; }
        string id;
        string description;
        bool result;

        public Category(string ID, string Name, string Description)
        {
            id = ID;
            name = Name;
            description = Description;
            tests = new ObservableCollection<AbstractTest>();
        }

        public void addTest(AbstractTest test)
        {
            tests.Add(test);
        }

        public bool execute()
        {
            bool categoryResult = true;
            foreach(ITest test in tests)
            {
                categoryResult &= test.execute();
            }
            result = categoryResult;
            return categoryResult;
        }

        public bool fixSetting()
        {
            bool result = true;
            foreach (ITest test in tests)
            {
                result = result & test.fixSetting();
            }
            return result;
        }

        public string getDescription()
        {
            return description;
        }

        public string getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public bool? getResult()
        {
            return result;
        }

        public IList<AbstractTest> getTests()
        {
            return tests;
        }
    }
}
