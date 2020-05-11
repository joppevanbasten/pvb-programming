using System.Collections.Generic;
using DN.Puzzle.Color;

namespace DN
{
    public class ColorLevelData : LevelData
    {
        public IEnumerable<LineData> Lines => lines;
        public IEnumerable<NodeData> Nodes => nodes;
        
        private List<LineData> lines;
        private List<NodeData> nodes;

        public ColorLevelData()
        {
            lines = new List<LineData>();
            nodes = new List<NodeData>();
        }

        public LineData CreateLine()
        {
            LineData lineData = new LineData();
            lines.Add(lineData);
            return lineData;
        }
    }
}