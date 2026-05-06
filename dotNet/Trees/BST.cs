namespace Trees;

public class BST
{
    private TreeNode root;
    public TreeNode Root
    {
        get { return root; }
        set { root = value; }
    }
    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    public TreeNode InsertRecursive(TreeNode? root, int value)
    {
        if (root == null)
        {
            root = new TreeNode(value);
        }

        //Recursive case
        if (root.Val > value)
        {
            root.Right = InsertRecursive(root.Right, value);
        }
        else
        {
            root.Left = InsertRecursive(root.Left, value);
        }

        return root;
    }

    public bool Search(int value)
    {
        return SearchRecursive(root, value);
    }
    public bool SearchRecursive(TreeNode? root, int value)
    {// TODO: 
        // BASE CASE:
        // if null, not found
        // if == is true, found!
        if (root == null) return false;
        if (root.Val == value) return true;

        // RECURSIVE CASE:
        // if value is greater, search the right sub-tree
        // else, search the left sub-tree
        if (root.Val > value) return SearchRecursive(root.Right, value);
        return SearchRecursive(root.Left, value);
    }

    public void Delete(int value)
    {
        Root = DeleteRecursive(Root, value);
    }
    public TreeNode? DeleteRecursive(TreeNode? root, int value)
    {
        if (root == null) return root;
        
        // find InorderSuccessor (the biggest node of right-subtree)
        // swap the value of node with InorderSuccessor.
        // Call the DeleteRecursive() with the right child and value.
        // return root
        if (root.Val < value)
        {
            root.Right = DeleteRecursive(root.Right, value);
        } else if (root.Val > value)
        {
            root.Left = DeleteRecursive(root.Left, value);
        }
        else
        {
            if (root.Left == null && root.Right == null) //it has no children
            {
                return null;
            }
            else if (root.Left == null) //one child
            {
                root = root.Right;
            }
            else if(root.Right == null) //one child
            {
                root = root.Left;
            }
            else //it has 2 children
            {
                TreeNode successor = GetInorderSuccessor(root.Right);
                (root.Val, successor.Val) = (successor.Val, root.Val);
                root.Right = DeleteRecursive(root.Right, value);
            }
        }

        return root;
    }
    private TreeNode? GetInorderSuccessor(TreeNode node) // get the smallest value that is less than node
    {
        int minValue = node.Val;
        while (node.Left != null)
        {
            minValue = node.Left.Val;
            node = node.Left;
        }
        return node;
    }
    public void InOrderTraversal()
    {
        InOrderTraversalRecursive(root);
    }

    private void InOrderTraversalRecursive(TreeNode? root)
    {
        if (root != null)
        {
            InOrderTraversalRecursive(root.Left);
            Console.WriteLine($"{root.Val} -> ");
            InOrderTraversalRecursive(root.Right);
        }
    }
    public void PreOrderTraversal()
    {
        PreOrderTraversalRec(root);
    }

    private void PreOrderTraversalRec(TreeNode root)
    {
        if (root != null)
        {
            Console.WriteLine($"{root.Val} -> ");
            PreOrderTraversalRec(root.Left);
            PreOrderTraversalRec(root.Right);
        }
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversalRec(root);
    }

    private void PostOrderTraversalRec(TreeNode root)
    {
        if (root != null)
        {
            PostOrderTraversalRec(root.Left);
            PostOrderTraversalRec(root.Right);
            Console.WriteLine($"{root.Val} -> ");
        }
    }
}
