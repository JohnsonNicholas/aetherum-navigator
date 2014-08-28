using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.genLibrary
{
    public class BetweenValidator<T> : IValidator
        where T : IComparable
    {
        readonly T Min;
        readonly T Max;

        public BetweenValidator(T min, T max)
        {
            this.Min = min;
            this.Max = max;
        }

        public bool Validate(object input)
        {
            return Min.CompareTo(input) <= 0 && Max.CompareTo(input) >= 0;
        }
    }

    public class CustomValidator<T> : IValidator
    {
        readonly Predicate<T> Validator;

        public CustomValidator(Predicate<T> validator)
        {
            this.Validator = validator;
        }

        public bool Validate(object input)
        {
            T typedInput = (T)input;
            return Validator(typedInput);
        }
    }
}
