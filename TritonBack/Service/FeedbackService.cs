using TritonBack.Data;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Service
{
    public class FeedbackService : IFeedback
    {
        private readonly DataContext context;

        public FeedbackService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<FeedbackModel>> GetFeedback()
        {
            var response = context.feedbacks.ToList();
            return response;
        }

        public async Task<FeedbackModel> PostFeedback(FeedbackModel feedback)
        {
            if (feedback == null)
            {
                throw new Exception("Заполните данные");
            }

            if (feedback.Name == string.Empty)
            {
                throw new Exception("Заполните Имя");
            }

            if (feedback.Surname == string.Empty)
            {
                throw new Exception("Заполните Фамилию");
            }

            if (feedback.Email == string.Empty)
            {
                throw new Exception("Заполните Почту");
            }

            var feedbackPeson = new FeedbackModel()
            {
                Name = feedback.Name,
                Surname = feedback.Surname,
                Email = feedback.Email,
                Questions= feedback.Questions,
            };

            context.AddAsync(feedbackPeson);
            context.SaveChanges();
            return feedbackPeson;

        }

        
    }
}
