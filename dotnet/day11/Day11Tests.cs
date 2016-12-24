﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day11
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void UnitTests()
        {
            /*
             this tests for equivalent states, which requires:
             - the elevator is on the same floor
             - all pairs of chip/generator positions have a matching set in each state
               which pairs are in which position doesn't matter

             this tests that the following are equivalent:
            
             F4 .  .  .  .  LG .  .
             F3 .  .  HG .  .  BM .
             F2 .  .  .  LM .  .  .
             F1 E  HM .  .  .  .  BG
            
             F4 .  .  .  .  HG .  .  
             F3 .  .  BG .  .  LM .  
             F2 .  .  .  HM .  .  .  
             F1 E  BM .  .  .  .  LG 
            
             they both evaluate to this equivalency state: 1(4,2)(3,1)(3,1)
            */
            var s1 = new State(4);
            s1.Items.AddRange(new Item[]
            {
                new Item(ItemType.Microchip, "Hydrogen", 1),
                new Item(ItemType.Microchip, "Lithium", 2),
                new Item(ItemType.Microchip, "Boron", 3),
                new Item(ItemType.Generator, "Hydrogen", 3),
                new Item(ItemType.Generator, "Lithium", 4),
                new Item(ItemType.Generator, "Boron", 1)
            });

            var s2 = new State(4);
            s2.Items.AddRange(new Item[]
            {
                new Item(ItemType.Microchip, "Hydrogen", 2),
                new Item(ItemType.Microchip, "Lithium", 3),
                new Item(ItemType.Microchip, "Boron", 1),
                new Item(ItemType.Generator, "Hydrogen", 4),
                new Item(ItemType.Generator, "Lithium", 1),
                new Item(ItemType.Generator, "Boron", 3)
            });

            Assert.AreEqual(s1.ToString(), s2.ToString(), "toString() should be equal");

            var list = new List<State>();
            list.Add(s1);

            Assert.IsTrue(list.Contains(s2));
        }

        [TestMethod]
        public void Example()
        {
            var solver = new Solver();

            var expected = 11;
            var actual = solver.Example();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var solver = new Solver();
            var expected = 33;

            var actual = solver.Part1();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var solver = new Solver();
            var expected = 57;

            var actual = solver.Part2();

            Assert.AreEqual(expected, actual);
        }
    }
}
