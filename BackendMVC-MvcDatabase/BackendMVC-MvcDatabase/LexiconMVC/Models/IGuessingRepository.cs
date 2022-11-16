namespace LexiconMVC.Models
{
    public interface IGuessingRepository
    {
        int Generat();

        bool Guess(Guessing guessing, Int32 tal);
    }
}
