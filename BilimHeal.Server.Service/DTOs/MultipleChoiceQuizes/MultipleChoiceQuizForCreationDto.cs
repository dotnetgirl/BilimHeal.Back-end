namespace BilimHeal.Server.Service.DTOs.MultipleChoiceQuizes;

public class MultipleChoiceQuizForCreationDto
{
    public string Question { get; set; }
    public List<string> Options { get; set; }
    public string Answer { get; set; }
    public short Format { get; set; }
}
