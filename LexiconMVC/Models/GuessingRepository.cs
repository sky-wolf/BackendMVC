
namespace LexiconMVC.Models
{
    public class GuessingRepository : IGuessingRepository
    {
        public int Generat()
        {
            Random random = new Random();

            int tal = random.Next(1, 101);
            return tal;

        }
        public bool Guess(Guessing guessing, Int32 tal)
        {
            if (guessing.Number != tal)
            {
                if (tal > guessing.Number)
                {
                    guessing.Massage = "Guess to smal!";
                    guessing.Guess = guessing.Guess + 1;
                }

                else if (tal < guessing.Number)
                {
                    guessing.Massage = "Guess to big!";
                    guessing.Guess = guessing.Guess + 1;
                }else
                {
                    guessing.Massage = "Invalid Number";
                }

                return false;
            }
            if (guessing.Number == tal)
            {
                guessing.Guess = guessing.Guess + 1;
                return true;
            }

            guessing.Massage = "Invalid input";
            return false;
        }
    }
}