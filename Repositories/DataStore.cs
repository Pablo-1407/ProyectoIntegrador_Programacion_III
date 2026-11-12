using RutaCampus.Common;
using RutaCampus.Contratos;
using System;
using System.Collections.Generic;

namespace RutaCampus.Repositories
{
    internal class DataStore<T> : IDataStore<T> where T : class, IFactory<T>, ISerialize<T>
    {
        private readonly string _path;

        public DataStore(string path)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(path);
            _path = Path.GetFullPath(path);
        }

        public IEnumerable<T> LoadAll()
        {
            DoubleLinkList<T> list = new DoubleLinkList<T>();
            if (!File.Exists(_path))
                return list;

            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    list.Add(T.Create(line));
                }
            }
            return list;
        }

        public void SaveAll(IEnumerable<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            string? directory = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            using (StreamWriter writer = new StreamWriter(_path, false))
            {
                foreach (T item in items)
                {
                    ArgumentNullException.ThrowIfNull(item);
                    writer.WriteLine(T.Serialize(item));
                }
            }
        }
    }
}
