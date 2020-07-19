namespace RuntimeCompilation.MathematicalOperations
{
    public class Subtract : IMathematicalOperation
    {
        public int Execute(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}