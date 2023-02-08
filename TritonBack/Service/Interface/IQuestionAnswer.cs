using Microsoft.AspNetCore.Mvc;
using TritonBack.Model;

namespace TritonBack.Service.Interface
{
    public interface IQuestionAnswer
    {
        public Task<QuestionsModel> CreateQuestionModel(QuestionsModel questionModel);
        public Task<QuestionsModel> UpdateQuestionModel(int id, QuestionsModel questionsModel);
        public Task DeleteQuestionModel(int id);
        public Task<List<QuestionsModel>> GetQuestionModel();

    }
}
