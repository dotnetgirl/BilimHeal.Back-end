using BilimHeal.Server.Domain.Commons;

namespace BilimHeal.Server.Domain.Entities;

public class QuizResult : Auditable
{
    public int CorrectAnswers { get; set; }
    public double Score { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
