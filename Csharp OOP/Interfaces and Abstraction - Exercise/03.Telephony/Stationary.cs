using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Stationary : ICall
    {
        private string number;

        public string Number 
        { 
            get => this.number;
            set
            {

                if (value.Any(char.IsLetter))
                {
                    throw new ArgumentException(String.Format(ExeptionMessages.InvalidNumberMessage));
                }

                this.number = value;
            }
        }

        public string Call()
        {
            return $"Dialing... {this.number}";
        }
    }
}
