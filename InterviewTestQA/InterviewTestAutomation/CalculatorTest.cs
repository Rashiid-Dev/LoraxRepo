using InterviewTestQA.InterviewTestAutomation;

namespace InterviewTestQA
{
    public class CalculatorTest
    {
        Calculator _calculator = new Calculator();

        [Fact]
        public void Subtract()
        {           
            Assert.Equal(6, _calculator.Subtract(10, 4));
            Assert.Equal(27655, _calculator.Subtract(34000, 6345));
            Assert.Equal(0, _calculator.Subtract(0, 0));
            Assert.Equal(0, _calculator.Subtract(-50, -50));
        }

        [Fact]
        public void Add()
        {

            Assert.Equal(0, _calculator.Add(0, 0));

            Assert.Equal(1382811, _calculator.Add(1000000, 382811));

            Assert.Equal(-2000, _calculator.Add(-1500, -500));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(0, _calculator.Multiply(0, 0));

            Assert.Equal(3285, _calculator.Multiply(657, 5));

            Assert.Equal(1530, _calculator.Multiply(-45, -34));

            Assert.Equal(-600, _calculator.Multiply(-10, 60));
        }

        [Fact]
        public void Divide()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Divide(0, 0));

            Assert.Equal(0, _calculator.Divide(0, 8));

            Assert.Equal(-6, _calculator.Divide(-10, 60));
        }
        [Fact]
        public void Square()
        {
            Assert.Equal(25, _calculator.Square(5));
            Assert.Equal(49, _calculator.Square(7));
        }
        [Fact]
        public void SquareRoot()
        {
            Assert.Equal(5, _calculator.SquareRoot(25));
            Assert.Equal(7, _calculator.SquareRoot(49));
        }
    }
}