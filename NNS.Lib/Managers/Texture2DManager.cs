using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NNS.Lib.Managers
{
    public class Texture2DManager
    {
        private static Dictionary<String, Texture2D> _textures;

        private static Texture2DManager _instance;
        private static ContentManager _content;


        public Texture2DManager(ContentManager content)
        {
            _instance = this;
            _content = content;
            _textures = new Dictionary<string, Texture2D>();
        }

        public Texture2D get(String path)
        {
            if (!_textures.ContainsKey(path))
            {
                _textures.Add(path, _content.Load<Texture2D>("Textures/" + path));
            }
            return _textures[path];
        }

        public static Texture2DManager Instance
        {
            get { return _instance; }
        }


    }
}
