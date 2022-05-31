using System.Net.Security;

namespace webShop.Model;

public class ServiceResult<T>
{
    public T? Value { get; set; }
    public List<string> Errors { get; set; } = new();
    public bool IsSuccess => Errors.Any();
}