using ContainRs.WebApp.Models;

namespace ContainRs.Testes
{
    public class EmailCtor
    {
        [Fact]
        public void Deve_Lancar_ArgumentException_Quando_Valor_Invalido()
        {
            /// arange
            string emailInvalido = "valor qualquer";

            /// act & assert
            Assert.Throws<ArgumentException>(() =>
            {
                Email email = new Email(emailInvalido);
            });
            
        }
    }
}