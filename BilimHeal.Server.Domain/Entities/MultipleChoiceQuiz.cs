using BilimHeal.Server.Domain.Commons;

namespace BilimHeal.Server.Domain.Entities;

public class MultipleChoiceQuiz : Auditable
{
    public string Question { get; set; }
    public List<string> Options { get; set;}
    public string Answer { get; set; }
    public string UserAnswer { get; set; }
    public short Format { get; set; }
}
