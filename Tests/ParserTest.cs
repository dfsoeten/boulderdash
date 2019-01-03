using System;
using System.IO;
using System.Linq;
using Xunit;
using Boulderdash.app.controller;
using Boulderdash.app.models;

namespace Tests
{
    public class ParserTest
    {
        private const string LevelsPath = @"../../../../Boulderdash/Levels";
        
        [Fact]
        public void TestAmountOfLevels()
        {
            //Arrange
            Parser result;
            
            //Act
            result = new Parser(LevelsPath);
            
            //Assert
            Assert.Equal(Directory.EnumerateFiles(LevelsPath).Count(), result.Levels.Count);
        }

        [Fact]
        public void TestAmountOfEntities()
        {
            //Arrange
            Level result;
            
            //Act
            result = (new Parser(LevelsPath)).Levels.First.Value;
            
            //Assert
//            Assert.Equal(82, result.Boulders.Count);
//            Assert.Equal(11, result.Diamonds.Count);
//            Assert.Single(result.FireFlies);
        }
    }
}