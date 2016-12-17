using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day11
{
    interface IItem
    {
        string Type { get; }
    }
    class Microchip : IItem
    {
        public string Type { get; private set; }

        public Microchip(string type)
        {
            Type = type;
        }
    }
    class Generator : IItem
    {
        public string Type { get; private set; }

        public Generator(string type)
        {
            Type = type;
        }
    }
    class Floor
    {
        public List<IItem> Items { get; private set; }

        public Floor()
        {
            Items = new List<IItem>();
        }

    }
    class Elevator
    {
        public int Floor { get; set; }
        public List<IItem> Items { get; private set; }

        public Elevator()
        {
            Items = new List<IItem>();
            Floor = 1;
        }
    }
    class Building
    {
        public List<Floor> Floors { get; private set; }
        public Elevator Elevator { get; private set; }

        public Building(int floors)
        {
            Floors = new List<Floor>();
            for (int i = 0; i < floors; i++)
                Floors.Add(new Floor());

            Elevator = new Elevator();
        }

        public IEnumerable<string> Display()
        {
            var itemTypes = Floors.SelectMany(f => f.Items.Select(i => i.Type));

            for (int i = Floors.Count; i > 0; i--)
            {
                var sb = new StringBuilder();

                foreach(var type in itemTypes)
                {
                    if (Floors[i-1].Items.Any(item => item.Type == type))
                        sb.AppendFormat(" {0} ", type);
                    else
                        sb.Append(" . ");
                }

                yield return string.Format("F{0} {1} {2}", i, Elevator.Floor == i ? string.Format("[{0}]", string.Concat(Elevator.Items.Select(eitem => eitem.Type))) : ".", sb.ToString());
            }
        }
    }

    public class Solver
    {
        public int Example()
        {
            var building = new Building(4);

            building.Floors[0].Items.Add(new Microchip("HM"));
            building.Floors[0].Items.Add(new Microchip("LM"));
            building.Floors[1].Items.Add(new Generator("HG"));
            building.Floors[2].Items.Add(new Generator("LG"));

            foreach (var line in building.Display())
                Console.WriteLine(line);

            return -1;
        }


    }
}
