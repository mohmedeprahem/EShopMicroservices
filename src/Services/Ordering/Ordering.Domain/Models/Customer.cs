namespace Ordering.Domain.Models;

public sealed class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    private Customer(CustomerId id, string name, string email) : base(id)
    {
        Name = name;
        Email = email;
    }

    public static Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        return new Customer(id, name, email);
    }
}
