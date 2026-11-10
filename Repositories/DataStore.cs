using RutaCampus.Common;
using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Repositories
{
    internal class DataStore<T> where T : class, IFactory<T>, ISerialize<T>
    {
        private string _path;
        public DataStore(string path)
        {
            _path = path;
        }

        public IEnumerable<T> GetAll()
        {
            DoubleLinkList<T> list = new DoubleLinkList<T>();
            if (!File.Exists(_path))
                return list;

            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine() ?? string.Empty;

                    if (string.IsNullOrEmpty(line))
                        continue;

                    list.Add(T.Create(line));
                }
            }
            return list;
        }

        public void SaveAll(IEnumerable<T> list)
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in list)
                sb.AppendLine(T.Serialize(item));

            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.Write(sb.ToString());
            }
        }
    }
}
