using Caelum.Stella.CSharp.Validation;
using Caelum.Stella.CSharp.Validation.Error;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            String cpf = "86288366757";
            CPFValidator validador = new CPFValidator();
            try
            {
                validador.IsValid(cpf);
                System.Console.WriteLine("CPF VÁLIDO");
            }
            catch (InvalidStateException e)
            {
                System.Console.WriteLine("CPF INVÁLIDO : " + e);
            }
            System.Console.ReadKey();
        }
    }
}