using c2_DecoupleViewAndViewModel.Models;

namespace c2_DecoupleViewAndViewModel.Services;

public static class DummyService
{
    public static async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        await Task.Delay(3000);
        return [new Customer(){ ID = 1, Name = "Jim" }, new Customer(){ ID = 2, Name = "Bob" }];
    }
}
