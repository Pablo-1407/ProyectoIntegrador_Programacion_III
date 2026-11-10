using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Common
{
    public abstract class Singleton<T> where T : class
    {
        private static T? _instance;
        private static readonly object _lock = new();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            // Crea la instancia de forma segura, incluso si el constructor es privado
                            _instance = Activator.CreateInstance(typeof(T), true) as T;
                        }
                    }
                }
                return _instance!;
            }
        }
    }
}

