﻿using System.Collections.Generic;
using zasz.me.Models;

namespace zasz.me.Services.Contracts
{
    /// <summary>
    /// SOFU : Stack Overflow; Server Fault; Super User :)
    /// </summary>
    public interface ISofuService
    {
        Pair<bool, List<Answer>> QuestionsAnswered(int page);
        void PopulateTitles(List<Answer> answers);
    }
}