using System;

namespace Martin {

    public class ActionBuilder {

        private Func<IActionFactory> _factoryActivator;
        private static readonly ActionBuilder _instance = new ActionBuilder();

        public static ActionBuilder Current {
            get { return _instance; }
        }

        public ActionBuilder() {
            var defaultActionFactory = new DefaultActionFactory();
            _factoryActivator = () => defaultActionFactory;
        }

        public void SetActionFactory(IActionFactory actionFactory) {
            if (actionFactory == null) {
                throw new ArgumentNullException("actionFactory");
            }
            _factoryActivator = () => actionFactory;
        }

        public IActionFactory GetActionFactory() {
            return _factoryActivator();
        }
    }
}