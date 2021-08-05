using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Praxis.Core.DataStructure
{
    public class NTreeNode
    {
        public int val;
        public List<NTreeNode> children;

        public NTreeNode() { }

        public NTreeNode(int _val, List<NTreeNode> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
