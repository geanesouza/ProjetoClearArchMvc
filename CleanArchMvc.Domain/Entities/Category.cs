using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
	// sealed -> não pode ser herdada
	// private set -> os valores das propriedades não poderão ser mudados externamente
	// para criar um instancia de Category usa-se construtores parametrizados 
	// definir validação do dominio por meio da classe criada DomainException - regras de dominio
	public sealed class Category : Entity
	{
		
		public string Name { get; private set; }

		public Category(string name)
		{
			ValidateDomain(name);
		}

		public Category(int id, string name)
		{

			DomainExceptionValidation.When(id < 0,
			"Invalid Id value");

			Id = id;
			ValidateDomain(name);
		}

		public void Update(string name)
		{
			ValidateDomain(name);
		}


		// propriedade de navegação
		public ICollection<Product>	Products { get; set; }

		private void ValidateDomain(string name)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
			"Invalid name. Name is required");

			DomainExceptionValidation.When(name.Length < 3,
			"Invalid name. Too short, minimum 3 characteres");

			Name = name;
		}

	}
}
