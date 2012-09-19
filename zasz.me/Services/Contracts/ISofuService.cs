using System.Collections.Generic;

namespace zasz.me.Services.Contracts
{
    /// <summary>
    /// SOFU : Stack Overflow; Server Fault; Super User :)
    /// </summary>
    public interface ISofuService
    {
        List<int> QuestionsAnswered();
        Dictionary<int, string> QuestionTitles(List<int> questionIds);
    }
}