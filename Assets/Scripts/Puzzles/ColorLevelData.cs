using System.Collections.Generic;
using System.Linq;
using DN.Puzzle.Color;
using DN.Puzzle.Color.Editor;
using UnityEngine;

namespace DN.Puzzle.Color
{
    /// <summary>
    /// Holds the data for a specific Color Puzzle level that is
    /// then in turn loaded in by either the level editor or the color puzzle itself.
    /// </summary>
    public class ColorLevelData : LevelData
    {
        public IEnumerable<LineData> Lines => lines;
        public IEnumerable<NodeData> Nodes => nodes;
        
        [SerializeField] private LineData[] lines;
        [SerializeField] private NodeData[] nodes;

        public bool SetData(object sender, IEnumerable<NodeData> nodeData, IEnumerable<LineData> lineData)
        {
            if (sender.GetType() != typeof(PuzzleEditor))
            {
                return false;
            }

            lines = lineData.ToArray();
            nodes = nodeData.ToArray();
            return true;
        }
    }

    public class LevelEditorColorData
    {
        public IEnumerable<NodeData> Nodes => NodeData;
        public IEnumerable<LineData> Lines => LineData;
        
        private List<NodeData> NodeData { get; set; }
        private List<LineData> LineData { get; set; }
        
        public LevelEditorColorData(IEnumerable<NodeData> nodeData, IEnumerable<LineData> lineData)
        {
            LineData = new List<LineData>(lineData);
            NodeData = new List<NodeData>(nodeData);
        }

        public LineData CreateLine()
        {
            var lineData = new LineData();
            return AddLine(lineData);
        }

        public LineData AddLine(LineData lineData)
        {
            LineData.Add(lineData);
            return lineData;
        }

        public NodeData CreateNode()
        {
            var nodeData = new NodeData();
            return AddNode(nodeData);
        }

        public NodeData AddNode(NodeData data)
        {
            NodeData.Add(data);
            return data;
        }

        public bool RemoveNode(NodeData data) => NodeData.Remove(data);
        public bool RemoveLine(LineData data) => LineData.Remove(data);
    }
}