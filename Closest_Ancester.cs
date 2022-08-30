/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    
    private TreeNode ans;
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        List<TreeNode> visited = new List<TreeNode>();
        return PostOrder(root, p, q, visited);
//         PostOrder(root, p, q);
//         return ans;
      
    }
    
//     private bool PostOrder(TreeNode currentNode, TreeNode p, TreeNode q){
//         if(currentNode == null){
//             return false;
//         }
        
//         int left = PostOrder(currentNode.left, p, q)? 1: 0;
//         int right = PostOrder(currentNode.right, p, q)? 1: 0;
//         int mid = (currentNode == p || currentNode == q)? 1: 0;
        
//         if( (mid + right + left) >= 2){
//             ans = currentNode;
//         }
        
//         return (mid + right + left)>0;
//     }
    
    
    
    public TreeNode PostOrder(TreeNode node, TreeNode p, TreeNode q, List<TreeNode> visited){
        if(node == null){
            return null;
        }
        
        List<TreeNode> myVisited = new List<TreeNode>();
        
        var leftNode = PostOrder(node.left, p, q, myVisited);
        if(leftNode != null){
            return leftNode;
        }
        var rightNode = PostOrder(node.right,  p, q, myVisited);      
        if(rightNode != null){
            return rightNode;
        }
        
        if(myVisited.Contains(p) && myVisited.Contains(q)){
            return node;
        }
        
        if(node == p || node == q){
            var othernode = node == p? q : p;
            if(myVisited.Contains(othernode)){
                return node;
            }
        }
        
        visited.Add(node);
        visited.AddRange(myVisited);
        
        return null;
    }
}