using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Position
    {
        private bool isAdmin;
        private string name;

        public Position(bool isAdmin, string name)
        {
            this.IsAdmin = isAdmin;
            this.Name = name;
        }

        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string Name { get => name; set => name = value; }
    }
}
