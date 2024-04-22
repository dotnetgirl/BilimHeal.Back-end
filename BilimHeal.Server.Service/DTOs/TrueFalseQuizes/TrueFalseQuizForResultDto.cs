namespace BilimHeal.Server.Service.DTOs.TrueFalseQuizes;

public class TrueFalseQuizForResultDto
{
    public long Id { get; set; }
    public string Question { get; set; }
    public bool Answer { get; set; }
    public short Format { get; set; }
}
