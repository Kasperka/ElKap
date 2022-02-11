using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Party
{
	public class PersonView
	{
		[Required] public string Id { get; set; }
		[DisplayName("First Name")] public string? FirstName { get; set; }
		[DisplayName("Last Name")] [Required] public string? LastName { get; set; }
		[DisplayName("Gender")] public bool? Gender { get; set; }
		[DisplayName("Date of birth")]public DateTime? DoB { get; set; }
		[DisplayName("Full Name")] public string? FullName { get; set; }
	}
}

