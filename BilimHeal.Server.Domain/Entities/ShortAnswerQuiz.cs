using BilimHeal.Server.Domain.Commons;

namespace BilimHeal.Server.Domain.Entities;

public class ShortAnswerQuiz : Auditable
{
    public string Question { get; set; }
    public string UserAnswer { get; set; }
    public string Answer { get; set; }
    public short Format { get; set; }
}
