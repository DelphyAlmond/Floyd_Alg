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

        private Graph GraphSnapshot;

        private Dictionary<string, Point> posInf;

        public Graph getSnapshot()
        {
            return GraphSnapshot;
        }

        public Dictionary<string, Point> getVPos()
        {
            return posInf;
        }

        public StateStep(string action, Graph graphSnapshot,
            Dictionary<string, Point> positions)
        {
            Action = action;
            GraphSnapshot = graphSnapshot;
            posInf = positions;
        }

        public override string ToString()
        {
            return Action;
        }
    }
}
