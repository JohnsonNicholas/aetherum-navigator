using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.genLibrary
{
    public class ValidationHandler : IValidator
    {
        public object DefaultValue { get; private set; }
        readonly List<IValidator> Validators;

        public ValidationHandler(object defaultValue)
        {
            this.DefaultValue = defaultValue;
            this.Validators = new List<IValidator>();
        }

        public ValidationHandler Between<T>(T min, T max)
        where T : IComparable
        {
            Validators.Add(new BetweenValidator<T>(min, max));
            return this;
        }

        public ValidationHandler Custom<T>(Predicate<T> validationFunc)
        {
            Validators.Add(new CustomValidator<T>(validationFunc));
            return this;
        }

        public bool Validate(object input)
        {
            return Validators.All(validator => validator.Validate(input));
        }
    }
}
