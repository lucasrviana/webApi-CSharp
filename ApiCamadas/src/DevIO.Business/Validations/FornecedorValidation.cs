using DevIO.Business.Models;
using DevIO.Business.Validations.documentos;
using FluentValidation;

namespace DevIO.Business.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser proenchido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
             {
                 RuleFor(f => f.Documento.Length).Equal((int)QuantidadeDoc.cpf)
                        .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
             });
            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal((int)QuantidadeDoc.cnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            });

            RuleFor(f => DocValidacao.Validar(f.Documento, f.TipoFornecedor)).Equal(true)
                .WithMessage("O Documento é invalido");
        }
    }
}


