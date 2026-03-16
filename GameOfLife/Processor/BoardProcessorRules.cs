using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Processor
{
    internal class BoardProcessorRule
    {
        string RuleName { get; set; }

        public Func<Board, int , int , bool> Condition { get; set; }
        public Action<Board, int, int> Action { get; set; }

        public BoardProcessorRule(Func<Board, int, int, bool> condition, Action<Board, int, int>? action, string name)
        {
            Condition = condition;
            RuleName = name;
            Action = action;
        }
    }
}
