using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NNS.Lib.Entities.Common;

namespace NNS.Lib.Managers
{
    public class GameObjectsManager
    {
        private static GameObjectsManager _instance;
        public static GameObjectsManager Instance()
        {
            if (_instance == null)
                _instance = new GameObjectsManager();

            return _instance;
        }

        private Dictionary<String,Object> _gameObjects;

        public GameObjectsManager()
        {
            _gameObjects = new Dictionary<string, Object>();
        }


        public void addObject<T>(UniqueID obj)
        {
            this._gameObjects.Add(obj.getID(), obj);
        }


        public Object getObject(String objName)
        {
            if (this._gameObjects.ContainsKey(objName))
            {
                return this._gameObjects[objName];
            }

            return null;
        }

    }
}
