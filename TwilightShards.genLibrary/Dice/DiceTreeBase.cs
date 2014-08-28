using System;
using System.Collections.Generic;

namespace TwilightShards.genLibrary
{
    public abstract class DiceTreeBase
    {
        public static KeyValuePair<int, DiceTreeBase> Init(int Key, DiceTreeBase Value)
        {
            return new KeyValuePair<int, DiceTreeBase>(Key, Value);
        }

        public static KeyValuePair<int, DiceTreeBase> Init<T>(int Key, T Value)
        {
            return new KeyValuePair<int, DiceTreeBase>(Key, new DiceTreeLeaf(Value));
        }

        public abstract T Walk<T>(params int[] values);
    }
}