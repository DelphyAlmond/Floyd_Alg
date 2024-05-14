using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydAlg
{
    public class StateStep
    {
        public string Action { get; set; }
        public Graph GraphSnapshot { get; set; }

        public StateStep(string action, Graph graphSnapshot)
        {
            Action = action;
            GraphSnapshot = graphSnapshot;
        }

        public override string ToString()
        {
            return Action;
        }
    }
}
