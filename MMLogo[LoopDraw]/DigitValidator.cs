namespace MentorMate
{
    public class DigitValidator
    {
        public bool IsValid(int rowsCount)
        {
            if (rowsCount > 2 && rowsCount < 10000 && rowsCount % 2 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
