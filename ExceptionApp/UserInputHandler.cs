using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionApp
{
    public class UserInputHandler
    {
        public bool Iterate { get; set; } = false;
        public string UserInput { get; private set; }

        private string[] _validStates = new string[] { "a", "u", "l", "f", "p", "x"};

        public void CheckInput(string userInput)
        {
            if (!_validStates.Contains(userInput))
            {
                Iterate = true;
                throw new InvalidUserInputException("Invalid option! Try again...");
            }
            if (userInput == "x")
            {
                Iterate = false;
                throw new UserHaltException("Application was halted by user...");
            }
            Iterate = true;
            UserInput = userInput;
        }
    }
}
