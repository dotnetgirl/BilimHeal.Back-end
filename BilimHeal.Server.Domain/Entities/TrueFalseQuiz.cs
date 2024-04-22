using BilimHeal.Server.Domain.Commons;

namespace BilimHeal.Server.Domain.Entities;

public class TrueFalseQuiz : Auditable
{
    public string Question { get; set; }
    public bool Answer { get; set; }
    public short Format { get; set; }
}
