using System;

namespace TwilightShards.genLibrary
{
    public class DiceTreeLeaf : DiceTreeBase
    {
        object value = null;

        public DiceTreeLeaf(object value)
        {
            this.value = value;
        }

        public override T Walk<T>(params int[] values)
        {
            if (value is T)
                return (T)value;
            else
                return default(T);
        }
    }
}
