using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TritonBack.Data;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Service
{
    public class QuestionAnswerService : IQuestionAnswer
    {
        private readonly DataContext context;
        public QuestionAnswerService(DataContext context)
        {
            this.context = context;
        }

        public async Task<QuestionsModel> GetQuestionModelById(int id)
        {
            var response = await context.questionsModels.FirstOrDefaultAsync(q=> q.Id == id);

            if (response == null)
            {
                throw new Exception("Такого вопроса/ответа не существует");
            }
            else
            {
                return response;
            }
        }
        public async Task<QuestionsModel> CreateQuestionModel(QuestionsModel questionModel)
        {
            if(questionModel == null)
            {
                throw new Exception("Список пуст");
            }

            if (questionModel.Question == string.Empty)
            {
                throw new Exception("Заполните Вопрос");
            }
            if (questionModel.Answer== string.Empty)
            {
                throw new Exception("Заполните Вопрос");
            }

            var newQuestionAnswer = new QuestionsModel()
            {
                Question = questionModel.Question,
                Answer = questionModel.Answer,
            };

            await context.questionsModels.AddAsync(newQuestionAnswer);
            await context.SaveChangesAsync();
            return newQuestionAnswer;

        }

        public async Task DeleteQuestionModel(int id)
        {
            var findQuestionAnswer = context.questionsModels.FirstOrDefault(q => q.Id == id);

            if (findQuestionAnswer != null)
            {
                context.questionsModels.Remove(findQuestionAnswer);
                context.SaveChanges();
            }
        }

        public async Task<List<QuestionsModel>> GetQuestionModel()
        {
           var response = context.questionsModels.ToList();
            return response;
        }

        public async Task<QuestionsModel> UpdateQuestionModel(int id, QuestionsModel questionsModel)
        {
            var findQuestionAnswer = context.questionsModels.FirstOrDefault(questionsModel=> questionsModel.Id == id);

            if (findQuestionAnswer == null)
            {
                throw new Exception("Такого вопроса/ответа не существует");
            } else 
            {
                findQuestionAnswer.Answer = questionsModel.Answer;
                findQuestionAnswer.Question = questionsModel.Question;
                context.Update(findQuestionAnswer);
                context.SaveChanges();
                return findQuestionAnswer;
            }
        }
    }
}
