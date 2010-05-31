using System;
using Martin;

namespace SampleWeb {

    public class DateAction : ActionBase {

        public override IResponse Get() {
            return Text(string.Format("The current date is {0}.", DateTime.Now));
        }
    }
}
