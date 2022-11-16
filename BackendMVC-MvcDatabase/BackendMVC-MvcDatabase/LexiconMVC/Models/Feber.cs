namespace LexiconMVC.Models
{
    public class Feber
    {
        public static string FeberCheck(int temp)
        {
            if (temp != 0)
            {
                if (temp >= 38)
                {
                    return "You have a feber";
                }
                else if (temp <= 35)
                {
                    return "You have hypothermia";
                }
                else if (temp >= 35 || temp <= 38)
                {
                    return "You dont have a fever!";
                }
            }
            return String.Empty;

        }

    }
}
