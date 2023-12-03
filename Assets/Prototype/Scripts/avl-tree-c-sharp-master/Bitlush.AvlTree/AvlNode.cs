namespace Prototype.Scripts.avl_tree_c_sharp_master.Bitlush.AvlTree
{
    public class AvlNode<TKey, TValue>
    {
        public AvlNode<TKey, TValue> Parent;
        public AvlNode<TKey, TValue> Left;
        public AvlNode<TKey, TValue> Right;
        public TKey Key;
        public TValue Value;
        public int Balance;
    }
}