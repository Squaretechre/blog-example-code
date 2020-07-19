namespace RuntimeCompilation.MathematicalOperations
{
    public class Add : IMathematicalOperation
    {
        public int Execute(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}