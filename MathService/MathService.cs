using DataTransferLayer;
using System;
using System.Text;

namespace MathService
{
    public class MathService : IMathService
    {
        double IMathService.Add(double firstValue, double secondValue) => firstValue + secondValue;
        double IMathService.Div(double firstValue, double secondValue) => firstValue / secondValue;
        double IMathService.Mult(double firstValue, double secondValue) => firstValue * secondValue;
        double IMathService.Sub(double firstValue, double secondValue) => firstValue - secondValue;

     
        public static double Calculate(string request)
        {
            string[] splitedRequest = request.Split(':');

            string operation = splitedRequest[0];
            double firstValue;
            double secondValue;
            bool f = double.TryParse(splitedRequest[1], out firstValue);
            bool s = double.TryParse(splitedRequest[2], out secondValue);

            if (!(f && s))
            {
                throw new Exception("Invalid imput!");
            }

            IMathService mathService = new MathService();

            switch (operation)
            {
                case "+":
                    return mathService.Add(firstValue, secondValue);
                case "-":
                    return mathService.Sub(firstValue, secondValue);
                case "*":
                    return mathService.Mult(firstValue, secondValue);
                case "/":
                    return mathService.Div(firstValue, secondValue);
                default:
                    throw new Exception("Invalid operation!");
            }
        }
    }
}
