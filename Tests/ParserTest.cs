using System;
using Xunit;
using Boulderdash.app.controller;

namespace Tests
{
    public class ParserTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Parser result;
            
            //Act
            result = new Parser(@"../../../../Boulderdash/Levels");
            
            //Assert
            Assert.Equal(4, result.Levels.Count);
        }
    }
}