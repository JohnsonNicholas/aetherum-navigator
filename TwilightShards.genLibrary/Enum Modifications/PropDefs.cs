using System;


namespace TwilightShards.genLibrary
{
    public class PropDefs : Attribute
    {
        ValType attrType;

        object minVal;
        object maxVal;
        object defVal;

        int minLength;

        public object defaultValue
        {
            get { return defVal; }
        }

        public object minValue
        {
            get { return minVal; }
        }

        public object maxValue
        {
            get { return maxVal; }
        }

        public ValType attributeType
        {
            get { return attrType; }
        }

        public int minStringLength
        {
            get { return minLength; }
        }

        public PropDefs(ValType v, object min, object max, object def, int length)
        {
            this.attrType = v;
            this.minVal = min;
            this.maxVal = max;
            this.defVal = def;
            this.minLength = length;
        }
    }
}