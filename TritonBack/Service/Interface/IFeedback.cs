using TritonBack.Model;

namespace TritonBack.Service.Interface
{
    public interface IFeedback
    {
        public Task<FeedbackModel> PostFeedback(FeedbackModel feedback);
    }
}
