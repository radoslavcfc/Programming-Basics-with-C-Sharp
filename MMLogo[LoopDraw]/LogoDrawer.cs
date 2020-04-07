using System;

namespace MentorMate
{
    public class LogoDrawer
    {
        private int rowsCount;

        private DigitValidator digitValidator;
        public LogoDrawer(int rowCount)
        {
            this.rowsCount = rowCount;
            this.digitValidator = new DigitValidator();
        }

        public void PrintOutput()
        {
            if (digitValidator.IsValid(rowsCount))
            {
                this.MainLogo();
                // Second solution :
                // Please uncomment to see result!
                //this.MainLogoNestedSwitchCase();
            }
            else
            {
                Console.WriteLine("Number must an odd number in range [2-10000] ");
            }
        }
        
        private void MainLogo()
        {
            for (int row = 0; row <= rowsCount; row++)
            {
                for (int i = 0; i < 2; i++)
                {

                    for (int col = 0; col < rowsCount; col++)
                    {
                        BlockOne(col, row, rowsCount);
                    }

                    for (int col = 0; col < rowsCount; col++)
                    {
                        BlockTwoAndFour(col, row, rowsCount);
                    }

                    for (int col = 0; col < rowsCount; col++)
                    {
                        BlockThree(col, row, rowsCount);
                    }

                    for (int col = 0; col < rowsCount; col++)
                    {
                        BlockTwoAndFour(col, row, rowsCount);
                    }

                    for (int col = 0; col < rowsCount; col++)
                    {
                        BlockFive(col, row);
                    }
                }

                Console.WriteLine();
            }
        }
        
        //Second solution involving Switch-Case statement, but too many levels of nesting.
        private void MainLogoNestedSwitchCase()
        {
            for (int row = 0; row <= rowsCount; row++)
            {
                //Loop starts from 1 just for better readability
                for (int block = 1; block <= 10; block++)
                {
                    for (int col = 0; col < rowsCount; col++)
                    {
                        switch (block)
                        {
                            case 1:
                            case 6:    
                                { BlockOne(col, row, rowsCount); }
                                break;
                            case 2:
                            case 4:
                            case 7:
                            case 9:
                                { BlockTwoAndFour(col, row, rowsCount); }
                                break;
                            case 3:
                            case 8:
                                { BlockThree(col, row, rowsCount); }
                                break;
                            case 5:
                            case 10:
                                { BlockFive(col, row); }
                                break;

                            default: break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }


        private void BlockOne(int col, int row, int rowsCount)
        {
            if (col < (rowsCount - row))
            {
                Console.Write("-");
            }
            else
            {
                Console.Write("*");
            }
        }

        private void BlockTwoAndFour(int col, int row, int rowsCount)
        {
            if ((row < (rowsCount + 1) / 2) ||
                           (col < rowsCount - row) ||
                           (row <= col))
            {
                Console.Write("*");
            }

            else
            {
                Console.Write("-");
            }
        }

        private void BlockThree(int col, int row, int rowsCount)
        {
            if ((row >= (rowsCount + 1) / 2) ||
                (row > col) ||
                (row >= (rowsCount - col)))
            {
                Console.Write("*");
            }
            else
            {
                Console.Write("-");
            }
        }

        private void BlockFive(int col, int row)
        {
            if (col >= row)
            {
                Console.Write("-");
            }
            else
            {
                Console.Write("*");
            }
        }
    }
}
