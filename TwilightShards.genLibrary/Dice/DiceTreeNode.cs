using System;
using System.Collections.Generic;
using System.Linq;

namespace TwilightShards.genLibrary
{
    public class DiceTreeNode : DiceTreeBase
    {
        DiceTreeBase[] Children = new DiceTreeBase[16];

        public DiceTreeNode()
        {

        }

        public DiceTreeNode(params KeyValuePair<int, DiceTreeBase>[] Params)
        {
            if (Params.Length == 0)
                return;

            foreach (KeyValuePair<int, DiceTreeBase> kvp in Params)
                Children[kvp.Key - 3] = kvp.Value;


            DiceTreeBase Last = null;
            for (int n = 0; n < 16; n++)
            {
                if (Children[n] != null)
                    Last = Children[n];
                else
                    Children[n] = Last;
            }
        }

        public void SetRange(int low, int high, DiceTreeBase node)
        {
            for (int n = low - 3; n < high - 3; n++)
            {
                Children[n] = node;
            }
        }

        public void SetRange(int low, int high, params KeyValuePair<int, DiceTreeBase>[] Params)
        {
            if (low - 3 < 0 || low - 3 > Children.Length)
                return;
            if (high - 3 < 0 || high - 3 > Children.Length)
                return;

            DiceTreeBase node = new DiceTreeNode(Params);
            for (int n = low - 3; n <= high - 3; n++)
            {
                Children[n] = node;
            }
        }

        public void SetNodeByKey(int key, DiceTreeNode node)
        {
            if (key - 3 < 0 || key - 3 > Children.Length)
               return;

            Children[key - 3] = node;
        }

        public void SetRange<T>(int low, int high, T value)
        {
            if (low - 3 < 0 || low - 3 > Children.Length)
                return;
            if (high - 3 < 0 || high - 3 > Children.Length)
                return;

            for (int n = low - 3; n < high - 3; n++)
            {
                Children[n] = new DiceTreeLeaf(value);
            }

        }

        public override T Walk<T>(params int[] values)
        {
            return Children[values[0]].Walk<T>(values.Skip(1).ToArray());
        }
    }

}
