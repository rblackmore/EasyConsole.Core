namespace EasyConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Menu
    {
        private IList<Option> Options { get; set; }

        public Menu()
        {
            this.Options = new List<Option>();
        }

        public void Display()
        {
            for (int i = 0; i < this.Options.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, this.Options[i].Name);
            }

            int choice = Input.ReadInt("Choose an option:", min: 1, max: this.Options.Count);

            Output.WriteLine("---");

            this.Options[choice - 1].Callback();
        }

        public Menu Add(string option, Action callback)
        {
            return Add(new Option(option, callback));
        }

        public Menu Add(Option option)
        {
            this.Options.Add(option);
            return this;
        }

        public bool Contains(string option)
        {
            return this.Options.FirstOrDefault((op) => op.Name.Equals(option)) != null;
        }
    }
}
