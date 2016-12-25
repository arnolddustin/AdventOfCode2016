using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day11
{
    public enum Directions { Up, Down };

    public enum ItemType { Microchip, Generator }

    public class Item : IEquatable<Item>
    {
        public ItemType ItemType { get; private set; }
        public string Compatibility { get; private set; }
        public int Floor { get; private set; }

        public Item(ItemType itemType, string compatibility, int floor)
        {
            ItemType = itemType;
            Compatibility = compatibility;
            Floor = floor;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Compatibility, ItemType);
        }

        public bool Equals(Item other)
        {
            return ToString() == other.ToString();
        }
    }

    public class State : IEquatable<State>
    {
        int NumberOfFloors { get; set; }
        int ElevatorFloor { get;  set; }

        public int Depth { get; private set; }
        public List<Item> Items { get; private set; }

        public State(int numberOfFloors, params Item[] items)
        {
            NumberOfFloors = numberOfFloors;
            Depth = 0;
            ElevatorFloor = 1;
            Items = new List<Item>(items);
        }

        private State(int numberOfFloors, int elevatorFloor, int depth, params Item[] items) : this(numberOfFloors, items)
        {
            ElevatorFloor = elevatorFloor;
            Depth = depth;
        }

        public bool IsSolved()
        {
            return Items.All(x => x.Floor == NumberOfFloors);
        }
        public bool IsSafe()
        {
            foreach (var chip in Items.Where(item => item.ItemType == ItemType.Microchip))
            {
                if (Items.Any(item => item.Floor == chip.Floor && item.ItemType == ItemType.Generator && item.Compatibility == chip.Compatibility))
                    continue;

                if (Items.Any(item => item.Floor == chip.Floor && item.ItemType == ItemType.Generator && item.Compatibility != chip.Compatibility))
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("{0}", ElevatorFloor);

            Items.Where(i => i.ItemType == ItemType.Microchip)
                .OrderBy(i => i.Floor)
                .ToList()
                .ForEach(chip =>
                    sb.AppendFormat("{0}{1}", chip.Floor,
                        Items.Single(i => i.ItemType == ItemType.Generator && i.Compatibility == chip.Compatibility)
                            .Floor));

            return sb.ToString();
        }

        public bool Equals(State other)
        {
            return ToString() == other.ToString();
        }

        public IEnumerable<State> GetChildren(HashSet<string> excludeStates)
        {
            var moves = FindAllPossibleMoves()
                       .Where(m => m.ElevatorFloor > 0 && m.ElevatorFloor <= m.NumberOfFloors)
                       .Where(m => !excludeStates.Contains(m.ToString()))
                       .Where(m => m.IsSafe());

            return moves;
        }

        State MoveItems(Directions direction, params Item[] itemsToMove)
        {
            var targetFloor = (direction == Directions.Up) ? ElevatorFloor + 1 : ElevatorFloor - 1;

            var items = new List<Item>();
            foreach (var item in Items)
                if (itemsToMove.Contains(item))
                    items.Add(new Item(item.ItemType, item.Compatibility, targetFloor));
                else
                    items.Add(item);

            return new State(NumberOfFloors, targetFloor, Depth + 1, items.ToArray());
        }

        IEnumerable<State> FindAllPossibleMoves()
        {
            var itemsOnFloor = Items.Where(item => item.Floor == ElevatorFloor);

            foreach (var pair in itemsOnFloor.Combinations(2))
            {
                yield return MoveItems(Directions.Up, pair.ToArray());
                yield return MoveItems(Directions.Down, pair.ToArray());
            }

            foreach (var item in itemsOnFloor)
            {
                yield return MoveItems(Directions.Up, item);
                yield return MoveItems(Directions.Down, item);
            }
        }
    }

    public static class Solver
    {
        public static int GetShortestSolution(State state)
        {
            var start = DateTime.Now;
            var results = FindShortestSolution(state);

            Console.WriteLine("Best solution uses {0} steps.", results);
            Console.WriteLine("Execution time: {0}", DateTime.Now - start);

            return results;
        }

        static int FindShortestSolution(State root)
        {
            var visited = new HashSet<string>();

            var queue = new Queue<State>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                var children = parent.GetChildren(visited);

                if (children == null || children.Count() == 0) continue;

                foreach (var child in children)
                {
                    visited.Add(child.ToString());

                    if (child.IsSolved())
                        return child.Depth;
                    else
                        queue.Enqueue(child);
                }
            }

            return 0;
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
}
