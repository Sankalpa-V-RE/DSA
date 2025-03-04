using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.BinaryTree
{
    internal class BinaryTree
    {
        public TreeNode Root { get; set; }
        public BinaryTree() { Root = null; }

        public void AddStaff(Staff staff)
        {
            if (Root == null)
                Root = new TreeNode(staff);
            else
                AddStaffRecursive(Root, staff);
        }

        private void AddStaffRecursive(TreeNode node, Staff staff)
        {
            if (string.Compare(staff.Name, node.StaffMember.Name) < 0)
            {
                if (node.Left == null)
                    node.Left = new TreeNode(staff);
                else
                    AddStaffRecursive(node.Left, staff);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new TreeNode(staff);
                else
                    AddStaffRecursive(node.Right, staff);
            }
        }

        public TreeNode SearchStaff(string name)
        {
            return SearchStaffRecursive(Root, name);
        }

        private TreeNode SearchStaffRecursive(TreeNode node, string name)
        {
            if (node == null || node.StaffMember.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                return node;
            if (string.Compare(name, node.StaffMember.Name) < 0)
                return SearchStaffRecursive(node.Left, name);
            else
                return SearchStaffRecursive(node.Right, name);
        }

        public void RemoveStaff(string name)
        {
            Root = RemoveStaffRecursive(Root, name);
        }

        private TreeNode RemoveStaffRecursive(TreeNode node, string name)
        {
            if (node == null)
                return node;

            if (string.Compare(name, node.StaffMember.Name) < 0)
                node.Left = RemoveStaffRecursive(node.Left, name);
            else if (string.Compare(name, node.StaffMember.Name) > 0)
                node.Right = RemoveStaffRecursive(node.Right, name);
            else
            {
                // Found the node to remove
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;

                node.StaffMember = FindMin(node.Right).StaffMember;
                node.Right = RemoveStaffRecursive(node.Right, node.StaffMember.Name);
            }
            return node;
        }

        private TreeNode FindMin(TreeNode node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        public List<Staff> GetAllStaff(TreeNode node)
        {
            List<Staff> staffList = new List<Staff>();
            if (node != null)
            {
                staffList.AddRange(GetAllStaff(node.Left));
                staffList.Add(node.StaffMember);
                staffList.AddRange(GetAllStaff(node.Right));
            }
            return staffList;
        }
    }
}
