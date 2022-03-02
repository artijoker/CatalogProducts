using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpModels
{
    public class Category
    {
        public Guid Id { get; }
        public string Name { get; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}