using AutoMapper;
using BilimHeal.Server.DAL.IRepositories;
using BilimHeal.Server.Domain.Entities;
using BilimHeal.Server.Service.Commons.Exceptions;
using BilimHeal.Server.Service.Commons.Helpers;
using BilimHeal.Server.Service.DTOs.QuizFormats;
using BilimHeal.Server.Service.Interfaces.Quizes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;

namespace BilimHeal.Server.Service.Services.Quizes;

public class QuizFormatService : IQuizFormatService
{
    private readonly IRepository<QuizFormat> _quizFormatRepository;
    private readonly IRepository<TrueFalseQuiz> _trueFalseQuizRepository;
    private readonly IRepository<ShortAnswerQuiz> _shortAnswerQuizRepository;
    private readonly IRepository<MultipleChoiceQuiz> _multipleChoiceQuizQuizRepository;
    private readonly IMapper _mapper;
    public QuizFormatService(IRepository<QuizFormat> quizFormatRepository, IMapper mapper, IRepository<TrueFalseQuiz> trueFalseQuizRepository, IRepository<ShortAnswerQuiz> shortAnswerQuizRepository, IRepository<MultipleChoiceQuiz> multipleChoiceQuizQuizRepository)
    {
        _quizFormatRepository = quizFormatRepository;
        _mapper = mapper;
        _trueFalseQuizRepository = trueFalseQuizRepository;
        _shortAnswerQuizRepository = shortAnswerQuizRepository;
        _multipleChoiceQuizQuizRepository = multipleChoiceQuizQuizRepository;
    }

    public async Task<dynamic> AddAsync(QuizFormatForCreationDto dto)
    {
        var mappedQuiz = _mapper.Map<QuizFormat>(dto);
        await _quizFormatRepository.InsertAsync(mappedQuiz);

        using (var client = new HttpClient())
        {
            var url = "https://question-generate.onrender.com/generate_questions/?";
            var payload = JsonConvert.SerializeObject(dto);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                await _quizFormatRepository.DeleteAsync(mappedQuiz.Id);

                var responseString = await response.Content.ReadAsStringAsync();

                // Now you can parse the response string as JSON
                var jsonObject = JObject.Parse(responseString);

                // Check if the "format" property exists and has a value of 3
                //if (jsonObject.TryGetValue("format", out var formatValue) && formatValue.Value<short>() == 1)
                //{
                //    return _mapper.Map<MultipleChoiceQuiz>(jsonObject);
                //}
                //if (jsonObject.TryGetValue("format", out var formatValue) && formatValue.Value<short>() == 2)
                //{

                //}
            }
              

                throw new CustomException((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
