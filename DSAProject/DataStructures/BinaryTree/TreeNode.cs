using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.BinaryTree
{
    internal class TreeNode
    {

        public Staff StaffMember { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(Staff staff)
        {
            StaffMember = staff;
            Left = null;
            Right = null;
        }
    }
}
