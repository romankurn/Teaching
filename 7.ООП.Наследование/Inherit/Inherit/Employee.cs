namespace Inherit
{
	public class Employee : Person
	{
		public string Organisation { get; set; }

		public Employee(string name, Gender gender, int age, string passport, string organisation)
			: base(name, gender, age, passport)
		{
			Organisation = organisation;
		}

		public void Introduce()
		{
			base.Introduce();
		}
	}
}
