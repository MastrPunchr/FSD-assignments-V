namespace Trees;

public class TreeNode
{
    public int Val;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int val)
    {
        Val = val;
        Left = null;
        Right = null;
    }

    public TreeNode(int val, TreeNode left, TreeNode right)
    {
        Val = val;
        Left = left;
        Right = right;
    }

    public void InsertLeft(TreeNode node)
    {
        Left = node;
    }

    public void InsertRight(TreeNode node)
    {
        Right = node;
    }
}