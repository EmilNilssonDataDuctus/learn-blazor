namespace BlazorApp.Data;

public class EmployeeInfo
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly LastLoggedIn { get; set; }
}
