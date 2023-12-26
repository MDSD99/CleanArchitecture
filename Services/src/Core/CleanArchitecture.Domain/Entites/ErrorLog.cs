using CleanArchitecture.Domain.Abstrations;

namespace CleanArchitecture.Domain.Entites;
public class ErrorLog: Entity
{
    public string ErrorMessage { get; set; }
    public string SackTrace { get; set; }
    public string RequestPath { get; set; }
    public string RequestMethod { get; set; }
    public DateTime Tİmestamp { get; set; }
}
