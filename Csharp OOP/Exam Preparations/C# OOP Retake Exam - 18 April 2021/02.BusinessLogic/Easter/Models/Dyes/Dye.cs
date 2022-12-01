using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get { return this.power; }
            private set 
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value; 
            }
        }

        public bool IsFinished()
        {
            if (this.Power == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            //return this.Power == 0;
        }

        public void Use()
        {
            this.Power -= 10;

            //if (this.Power < 0)
            //{
            //    this.Power = 0;
            //}
        }
    }
}
