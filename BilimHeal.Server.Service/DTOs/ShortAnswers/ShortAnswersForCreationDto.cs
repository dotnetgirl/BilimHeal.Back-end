namespace BilimHeal.Server.Service.DTOs.ShortAnswers;

public class ShortAnswersForCreationDto
{
    public string Question { get; set; }
    public string UserAnswer { get; set; }
    public string Answer { get; set; }
    public short Format { get; set; }
}
