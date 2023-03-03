using FluentAssertions;
using StrykerMutator.Domain;
using Xunit;

namespace StrykerMutatorTests
{
    public class PessoaTests
    {
        [Trait("Pessoa", "Sucesso")]
        [Fact(DisplayName = "Criar pessoa sucesso")]
        public void Criar_pessoa_sucesso()
        {
            //Act
            const string nomeValido = "Rodrigo Calazans Negrao";
            const int idadeValida = 35;

            //Arrange
            var action = () => new Pessoa(nomeValido, idadeValida);

            //Assert
            var pessoa = action.Should().NotThrow().Which;
            pessoa.Id.Should().NotBeEmpty();
            pessoa.Nome.Should().Be(nomeValido);
            pessoa.Idade.Should().Be(idadeValida);
        }

        [Trait("Pessoa", "Sucesso")]
        [Theory(DisplayName = "Criar pessoa nome valido sucesso")]
        [InlineData("Rodrigo Calazans")]
        [InlineData("Antonio Carlos")]
        public void Criar_pessoa_sucesso_nome_valido(string nomeValido)
        {
            var action = () => new Pessoa(nomeValido, 35);
            action.Should().NotThrow();
        }

        [Trait("Pessoa", "Resultao esperado")]
        [Theory(DisplayName = "Criar pessoa idade difernte retorna resultado esperado")]
        [InlineData(16, false)]
        [InlineData(35, true)]

        /* limites (comentar as duas linhas abaixo para e executar Stryker*/
        [InlineData(17, false)]
        [InlineData(18, true)]
        public void Criar_pessoa_idade_diferente_deve_retornar_resultado_esperado(int idade, bool resultadoEsperado)
        {
            //Act
            var pessoa = new Pessoa("Rodrigo Calazans Negrao", idade);

            //Arrange
            var result = pessoa.MaiorDeIdade();

            //Assert
            result.Should().Be(resultadoEsperado);
        }

        [Trait("Pessoa", "Falha")]
        [Theory(DisplayName = "Criar pessoa nome invalido")]
        [InlineData("invalido")]
        [InlineData(null)]
        public void Criar_pessoa_falha_nome_invalido(string nomeInvalido)
        {
            //Act and Arrange
            var action = () => new Pessoa(nomeInvalido, 35);

            //Assert
            action.Should().Throw<Exception>()
                .WithMessage("Nome deve ser composto por nome e sobrenome");
        }
    }
}
