using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NNS.Lib.Utils
{
    public class Events
    {
        private static bool _debug = true;
        private static Dictionary<String, List<Action>> _actions;
        private static Dictionary<String, List<Action<Object>>> _functions;

        public static void fire(String name)
        {
            if (_debug)
                Console.WriteLine("Events.Fire => " + name);

            if (_actions == null)
                Initialize();

            if (_actions.ContainsKey(name))
            {
                List<Action> requestEvent = _actions[name];
                foreach (var item in requestEvent)
	            {
		            item.Invoke();
	            }
            }
        }

        public static void fire (String name, Object obj)
        {
            if (_debug)
                Console.WriteLine("Events.Fire => " + name + " args => " + obj.ToString());

            if (_functions == null)
                Initialize();

            if (_functions.ContainsKey(name))
            {
                List<Action<Object>> requestEvent = _functions[name];
                foreach (var item in requestEvent)
                {
                    item.Invoke(obj);
                }
            }
        }


        public static void register(String name, Action action)
        {


            if (_actions == null)
                Initialize();

            if (!_actions.ContainsKey(name))
            {
                _actions.Add(name, new List<Action>() { action });
            }
            else
            {
                _actions[name].Add(action);
            }

        }

        public static void register(String name, Action<Object> action)
        {
            if (_functions == null)
                Initialize();

            if (!_functions.ContainsKey(name))
            {
                _functions.Add(name, new List<Action<Object>>() { action });
            }
            else
            {
                _functions[name].Add(action);
            }

        }


        public static void unregister(string name, Action<Object> action)
        {
            if (_functions.ContainsKey(name))
            {
                List<Action<Object>> requestEvent = _functions[name];
                requestEvent.Remove(action);

                if (requestEvent.Count == 0)
                    _functions.Remove(name);
            }
        }

        public static void unregister(string name, Action action)
        {
            if (_functions.ContainsKey(name))
            {
                List<Action> requestEvent = _actions[name];
                requestEvent.Remove(action);

                if (requestEvent.Count == 0)
                    _actions.Remove(name);
            }
        }

        public static void unregister(Object obj)
        {
            foreach (var events in _actions)
            {
                for (int i = events.Value.Count-1; i > -1 ; i--)
                {
                    Action action = events.Value[i];
                    if (obj == action.Target)
                    {
                        events.Value.RemoveAt(i);
                    }
                }
            }

            foreach (var events in _functions)
            {
                for (int i = events.Value.Count - 1; i > -1; i--)
                {
                    Action<Object> action = events.Value[i];
                    if (obj == action.Target)
                    {
                        events.Value.RemoveAt(i);
                    }
                }
            }
        }

        private static void Initialize()
        {
            _actions = new Dictionary<string, List<Action>>();
            _functions = new Dictionary<string, List<Action<Object>>>();
        }
    }
}
