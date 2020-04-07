namespace NumberToAWord
{
    /// <summary>
    /// Main logic kept in this class
    /// </summary>
    public class NumberToWordTranslator
    {
        private int mainInputNumber;
        private int zeroToNineDigit;
        private int tenthDigit;
        private int hundredthDigit;
        private string result;

        private string[] zeroToTenArray = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        private string[] teensArray = { "Ten", "Eleven", "Twelve", "Thirteen", "teen", "Fifteen" };

        private string[] tentshArray = { "Twenty", "Thirty", "ty", "Fifty" };

        private string[] hundredsArray = { "Hundred", " and " };

        public string DigitController(int number)
        {
            this.mainInputNumber = number;

            this.DigitSeparator();

            if (this.mainInputNumber >= 0 && this.mainInputNumber <= 9)
            {
                this.result = this.ZeroToNine(this.zeroToNineDigit);
            }

            else if (this.mainInputNumber >= 10 && this.mainInputNumber <= 19)
            {
                this.result = this.Teens();
            }

            else if (this.mainInputNumber >= 20 && this.mainInputNumber <= 99)
            {
                this.result = this.NineTeenToNinetyNine();
            }

            else if (this.mainInputNumber >= 100 && this.mainInputNumber <= 999)
            {
                this.result = this.OverHundred();
            }

            return this.result;
        }
        private void DigitSeparator()
        {
            //First digit from right to left
            this.zeroToNineDigit = this.mainInputNumber % 10;

            //Second digit from right to left
            this.tenthDigit = (this.mainInputNumber / 10) % 10;

            //Third digit from right to left
            this.hundredthDigit = (this.mainInputNumber / 100) % 10;
        }
        /// <summary>
        ///  Eight + ty = Eightty
        ///  Eight + teen = Eightteen
        ///  This method removes the spare 't'
        /// </summary>
        /// <param name="digit">Parameter passed depending on the position of '8' in the number</param>
        private void EightDuplicateCharRemove(int digit)
        {
            if (digit == 8)
            {
                this.result = this.result.Remove(4, 1);
            }
        }
        private string ZeroToNine(int digit)
        {
            this.result = this.zeroToTenArray[digit];

            return this.result;
        }

        private string Teens()
        {
            if (this.mainInputNumber == 14 || this.mainInputNumber > 15)
            {
                this.result = zeroToTenArray[this.zeroToNineDigit] + this.teensArray[4];
            }
            else
            {
                this.result = teensArray[this.zeroToNineDigit];
            }

            this.EightDuplicateCharRemove(this.zeroToNineDigit);

            return this.result;
        }
        private string NineTeenToNinetyNine()
        {
            if (this.tenthDigit == 2 || this.tenthDigit == 3 || this.tenthDigit == 5)
            {
                this.result = this.tentshArray[this.tenthDigit - 2];
            }

            else
            {
                this.result = this.zeroToTenArray[this.tenthDigit] + this.tentshArray[2];
            }

            if (this.zeroToNineDigit != 0)
            {
                this.result += " " + this.zeroToTenArray[this.zeroToNineDigit];
            }

            EightDuplicateCharRemove(this.tenthDigit);

            return this.result;
        }

        private string OverHundred()
        {
            this.result = ZeroToNine(this.hundredthDigit) + " " + this.hundredsArray[0];

            if (this.tenthDigit != 0 || this.zeroToNineDigit != 0)
            {
                this.result += this.hundredsArray[1] + this.NineTeenToNinetyNine();
            }

            return this.result;
        }
    }
}

