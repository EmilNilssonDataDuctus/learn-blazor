namespace BlazorApp.Data;

public class EmployeesService
{
	public static Task<EmployeeInfo[]> GetEmployeesData()
	{
		GeneratedNameService NameService = new GeneratedNameService();
		return Task.FromResult(Enumerable.Range(1, 5).Select(index =>
		{
			string firstName = NameService.GetFirstName();
			string surName = NameService.GetSurnameName();

			return new EmployeeInfo
			{
				FirstName = firstName,
				LastName = surName,
				Email = $"{firstName}.{surName}@martinservera.se",
				UserName = $"{firstName}{surName}{Random.Shared.Next(11, 155)}",
				PhoneNumber = $"(046) 555-0{Random.Shared.Next(100, 200)}",
				LastLoggedIn = DateOnly.FromDateTime(DateTime.Now).AddDays(index*-1)
			};
		}).ToArray());
	}
}
